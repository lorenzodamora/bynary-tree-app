using System;
using System.IO;
using System.Windows.Forms;

namespace bynary_tree_app
{
	public partial class App : Form
	{
		private string mainCsvPath;
		private string mainTreePath;
		private BinaryTree main;

		private void App_Load(object sender, EventArgs e)
		{
			if(Starter.restart) ResetPaths_Click(null, null);
		}

		private void ResetPaths_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Paths = "";
			Starter.restart = true;
			Close();
		}

		public App()
		{
			InitializeComponent();
			btn_resetPaths.Visible = false;
			if(!GetPaths()) SetPaths();
			else
			{
				try
				{
					main = new BinaryTree(mainCsvPath, mainTreePath);
					SetVisible();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message, "Errore");
					Starter.restart = true;
				}
			}
		}

		private bool GetPaths()
		{
			string[] p = Properties.Settings.Default.Paths.Split('\n');
			if(p.Length != 2) return false;
			mainCsvPath = p[0];
			mainTreePath = p[1];
			return true;
		}

		private void SetPath_DragDrop(object sender, DragEventArgs e)
		{
			if(!e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.None;
				MessageBox.Show("Non valido", "Errore");
				return;
			}
			e.Effect = DragDropEffects.Copy;
		}

		private void SetPath_DragEnter(object sender, DragEventArgs e)
		{
			if(btn_setPath.Text == "Scegli file")
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(files.Length != 1) throw new ArgumentException("inserisci un singolo file");
				Properties.Settings.Default.Paths = files[0];
				txt_setPath.Text = "Trascina qua la cartella oppure";
				btn_setPath.Text = "Scegli cartella";
			}
			else
			{
				string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(folders.Length == 1 && Directory.Exists(folders[0]))
					EndSetPaths(folders[0]);
				else throw new Exception("inserisci una singola cartella");
			}
		}

		private void SetPath_Click(object sender, EventArgs e)
		{
			if(btn_setPath.Text == "Scegli file")
				using(OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.Title = "Seleziona un file";
					openFileDialog.Filter = "File CSV (*.csv)|*.csv"; // Puoi personalizzare i filtri dei file se necessario

					if(openFileDialog.ShowDialog() == DialogResult.OK)
					{
						Properties.Settings.Default.Paths = openFileDialog.FileName;
						txt_setPath.Text = "Trascina qua la cartella oppure";
						btn_setPath.Text = "Scegli cartella";
					}
				}
			else
				using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					folderBrowserDialog.Description = "Seleziona la cartella dei dettagli del binary tree, oppure una cartella vuota";

					if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
						EndSetPaths(folderBrowserDialog.SelectedPath);
				}
		}

		private void SetPaths()
		{
			btn_setPath.Visible = txt_setPath.Visible = true;
			txt_setPath.Location = new System.Drawing.Point(13, 13);
			btn_setPath.Location = new System.Drawing.Point(485, 13);
		}

		private void EndSetPaths(string add)
		{
			Properties.Settings.Default.Paths += "\n" + add;
			Properties.Settings.Default.Save();
			GetPaths();
			main = new BinaryTree(mainCsvPath, mainTreePath);
			btn_setPath.Visible = txt_setPath.Visible = false;
			SetVisible();
		}

		private void SetVisible()
		{
			//.Visible = true
			btn_resetPaths.Visible = true;
			MessageBox.Show(Properties.Settings.Default.Paths);
		}

		private void F1_Click(object sender, EventArgs e)
		{
			if(Directory.Exists(mainTreePath + "copy")) Directory.Delete(mainTreePath + "copy", true);
			CopyDirectory(mainTreePath, mainTreePath + "copy", true);

			void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
			{
				// Get information about the source directory
				var dir = new DirectoryInfo(sourceDir);

				// Check if the source directory exists
				if(!dir.Exists)
					throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

				// Cache directories before we start copying
				DirectoryInfo[] dirs = dir.GetDirectories();

				// Create the destination directory
				Directory.CreateDirectory(destinationDir);

				// Get the files in the source directory and copy to the destination directory
				foreach(FileInfo file in dir.GetFiles())
				{
					string targetFilePath = Path.Combine(destinationDir, file.Name);
					file.CopyTo(targetFilePath);
				}

				// If recursive and copying subdirectories, recursively call this method
				if(recursive)
				{
					foreach(DirectoryInfo subDir in dirs)
					{
						string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
						CopyDirectory(subDir.FullName, newDestinationDir, true);
					}
				}
			}

			Directory.Delete(mainTreePath, true);
			Directory.CreateDirectory(mainTreePath);

			main.CreaTreeFolder();
		}

	}
}
