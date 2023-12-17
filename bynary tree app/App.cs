using System;
using System.IO;
using System.Windows.Forms;

namespace bynary_tree_app
{
	public partial class App : Form
	{

		private string mainCsvPath;
		private string mainPagesPath;
		private BinaryTree main;

		public App()
		{
			InitializeComponent();
			if(!GetPaths()) SetPaths();
			else
			{
				main = new BinaryTree(mainCsvPath, mainPagesPath);
				SetVisible();
			}
		}

		private bool GetPaths()
		{
			string[] p = Properties.Settings.Default.Paths.Split('\n');
			if(p.Length != 2) return false;
			mainCsvPath = p[0];
			mainPagesPath = p[1];
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
			GetPaths();
			main = new BinaryTree(mainCsvPath, mainPagesPath);
			btn_setPath.Visible = txt_setPath.Visible = false;
			SetVisible();
		}

		private void SetVisible()
		{
			//.Visible = true
			MessageBox.Show(Properties.Settings.Default.Paths);
		}

	}
}
