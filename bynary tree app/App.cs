using System;
using System.IO;
using System.Text;
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

		private void Reload_Click(object sender, EventArgs e)
		{
			Starter.restart = true;
			Close();
		}

		public App()
		{
			InitializeComponent();
			tip_soloCsv.SetToolTip(btn_calcola,"sovrascrive solo il file csv, lascia invariato il folder");
			tip_soloCsv.SetToolTip(btn_sort,"sovrascrive solo il file csv, lascia invariato il folder");
			tip_soloCsv.SetToolTip(btn_resetPunti,"sovrascrive solo il file csv, lascia invariato il folder");
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
				btn_create.Text = "Genera cartella";
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
						btn_create.Text = "Genera cartella";
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

		TextBox txt_create;
		private void Create_Click(object sender, EventArgs e)
		{
			if(btn_create.Text == "Genera file" || btn_create.Text == "Genera cartella")
			{
				string nome = "Scrivi qua il nome del";
				if(btn_create.Text == "Genera file")
				{
					nome += " file";
					btn_create.Text = "Conferma nome file";
				}
				if(btn_create.Text == "Genera cartella")
				{
					nome += "la cartella";
					btn_create.Text = "Conferma nome cartella";
				}
				txt_create = new TextBox
				{
					Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
					Location = new System.Drawing.Point(169, 107),
					Name = "txt_create",
					Size = new System.Drawing.Size(465, 35),
					Text = nome,
					TextAlign = HorizontalAlignment.Center
				};
				Controls.Add(txt_create);
				return;
			}
			if(btn_create.Text == "Conferma nome file")
			{
				if(txt_create.Text.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
					throw new Exception("Il nome del file ha caratteri non validi");

				string path = null;
				using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					folderBrowserDialog.Description = "Seleziona la cartella dove inserire il nuovo file";

					if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
						path = folderBrowserDialog.SelectedPath;
				}

				string fpath = path + "\\" + txt_create.Text + ".csv";
				using(FileStream fs = new FileStream(fpath, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					string str = Persona.Head + "\r\n";
					Byte[] info = new UTF8Encoding(true).GetBytes(str);
					fs.Write(info, 0, info.Length);
				}

				Properties.Settings.Default.Paths = fpath;
				txt_setPath.Text = "Trascina qua la cartella oppure";
				btn_setPath.Text = "Scegli cartella";
				btn_create.Text = "Genera cartella";
				Controls.Remove(txt_create);
				txt_create.Dispose();
			}
			if(btn_create.Text == "Conferma nome cartella")
			{
				if(txt_create.Text.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
					throw new Exception("Il nome della cartella ha caratteri non validi");

				string path = null;
				using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					folderBrowserDialog.Description = "Seleziona la cartella dove inserire la nuova cartella";

					if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
						path = folderBrowserDialog.SelectedPath;
				}
				string dpath = path + "\\" + txt_create.Text;
				Directory.CreateDirectory(dpath);
				EndSetPaths(dpath);
			}
		}

		private void SetPaths()
		{
			btn_setPath.Visible = txt_setPath.Visible = btn_create.Visible = true;
			txt_setPath.Location = new System.Drawing.Point(13, 13);
			btn_setPath.Location = new System.Drawing.Point(485, 13);
			btn_create.Location = new System.Drawing.Point(12, 111);
		}

		private void EndSetPaths(string add)
		{
			Properties.Settings.Default.Paths += "\n" + add;
			Properties.Settings.Default.Save();
			GetPaths();
			try
			{
				main = new BinaryTree(mainCsvPath, mainTreePath);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Errore");
				ResetPaths_Click(null, null);
			}
			btn_setPath.Visible = txt_setPath.Visible = btn_create.Visible = btn_create.Visible = false;
			if(txt_create != null)
			{
				Controls.Remove(txt_create);
				txt_create.Dispose();
			}

			SetVisible();
		}

		private void SetVisible()
		{
			//.Visible = true
			btn_resetPaths.Visible = btn_f1.Visible = btn_f2.Visible = 
				btn_calcola.Visible = btn_sort.Visible = btn_resetPunti.Visible = true;
			MessageBox.Show(Properties.Settings.Default.Paths);
		}

		private void F1_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Sicuro?", "Conferma azione", MessageBoxButtons.YesNo) == DialogResult.No) return;
			bool copy = MessageBox.Show("Creare una copia del vecchio?", "Conferma azione", MessageBoxButtons.YesNo) == DialogResult.Yes;
			if(copy)
			{
				if(Directory.Exists(mainTreePath + "copy")) Directory.Delete(mainTreePath + "copy", true);
				CopyDirectory(mainTreePath, mainTreePath + "copy", true);
			}

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
			string msg = copy ? "Creata copia del sovrascritto" : "Sovrascrito";
			if(MessageBox.Show(msg + ".\nAprire la posizione?", "Conferma azione", MessageBoxButtons.YesNo) == DialogResult.Yes)
				System.Diagnostics.Process.Start("explorer.exe", Directory.GetParent(mainTreePath).FullName);
		}

		private void F2_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Sicuro?", "Conferma azione", MessageBoxButtons.YesNo) == DialogResult.No) return;
			bool copy = MessageBox.Show("Creare una copia del vecchio?", "Conferma azione", MessageBoxButtons.YesNo) == DialogResult.Yes;
			if(copy) File.Copy(mainCsvPath, mainCsvPath + "copy.csv", true);

			main.CreaTreeFile();
		}

		private void Calcola_Click(object sender, EventArgs e)
		{
			main.Calcoli();
			MessageBox.Show("fatto", "Calcolo");
		}

		private void Sort_Click(object sender, EventArgs e)
		{
			main.SortFile();
			MessageBox.Show("fatto", "Sort");
		}

		private void ResetPunti_Click(object sender, EventArgs e)
		{
			main.ResetPunti();
			MessageBox.Show("fatto", "Reset Punti");
		}
	}
}
