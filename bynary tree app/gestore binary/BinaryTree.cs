using System;
using System.IO;

namespace bynary_tree_app
{
	internal class BinaryTree
	{
		private string _pagesPath;
		public string PagesPath
		{
			get => _pagesPath;
			set
			{
				if(Directory.Exists(value))
				{
					//Console.WriteLine($"Il percorso '{value}' esiste.");
					// Verifica se il percorso rappresenta una cartella
					if((File.GetAttributes(value) & FileAttributes.Directory) == FileAttributes.Directory)
					{
						//Console.WriteLine($"Il percorso '{value}' rappresenta una cartella.");
						_pagesPath = value;
						return;
					}
				}
				throw new DirectoryNotFoundException($"la cartella {value} non esiste");
			}
		}

		private string _csvPath;
		public string FilePath
		{
			get => _csvPath;
			set
			{
				if(File.Exists(value))
				{
					// Verifica se il percorso rappresenta un file .csv
					if(Path.GetExtension(value).Equals(".csv", StringComparison.OrdinalIgnoreCase))
					{
						//Console.WriteLine($"Il percorso '{value}' rappresenta un file .csv.");
						_csvPath = value;
						return;
					}
				}

				throw new DirectoryNotFoundException($"Il file {value} non esiste o non è corretto");
			}
		}

		public BinaryTree() { /*path vuoto*/ }

		public BinaryTree(string filePath, string pagesPath)
		{
			FilePath = filePath;
			PagesPath = pagesPath;
		}

	}
}
