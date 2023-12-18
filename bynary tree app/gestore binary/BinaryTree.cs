using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bynary_tree_app
{
	internal class BinaryTree
	{
		private string _treePath;
		public string TreePath
		{
			get => _treePath;
			set
			{
				if(Directory.Exists(value))
				{
					//Console.WriteLine($"Il percorso '{value}' esiste.");
					// Verifica se il percorso rappresenta una cartella
					if((File.GetAttributes(value) & FileAttributes.Directory) == FileAttributes.Directory)
					{
						//Console.WriteLine($"Il percorso '{value}' rappresenta una cartella.");
						_treePath = value;
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

		public List<Persona> tree = new List<Persona>();

		public BinaryTree() { /*path vuoto*/ }

		public BinaryTree(string filePath, string treePath)
		{
			FilePath = filePath;
			TreePath = treePath;
			LoadFile();
			CheckList();
		}

		public void LoadFile()
		{
			if(!CheckHeaderFile()) throw new ArgumentException("Il file csv inserito ha head scorretto");
			string[] lines = File.ReadAllLines(_csvPath);
			for(int i = 1; i < lines.Length; ++i)
			{
				string[] split = lines[i].Split(',');
				int up = int.Parse(split[2]);
				if(up < -1) throw new Exception("Il file csv inserito ha almeno un id minore di -1");
				int pid = int.Parse(split[0]);
				if(pid == 0 && up != -1) throw new Exception("Il file csv inserito non ha in id:0 l'upline -1");
				if(pid != 0 && up == -1) throw new Exception($"Il file csv inserito ha in id:{pid} l'upline -1");
				if(pid < up) throw new Exception($"Il file csv inserito ha in id:{pid} un id più vecchio dell'upline:{up}");
				tree.Add(new Persona
				{
					id = pid,
					name = split[1],
					uplineId = up,
					sponsorId = int.Parse(split[3]),
					rank = split[4],
					contatto = split[5],
					city = split[6],
					nDiretti = int.Parse(split[7]),
					nDown = int.Parse(split[8]),
					imageUrl = split[9]
				});
			}
		}

		public bool CheckHeaderFile()
		{
			using(FileStream fs = new FileStream(_csvPath, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				int b;
				string line = "";
				while((b = fs.ReadByte()) > 0)
					if((char)b == '\n')
						return line.Trim().ToUpper() == "Personal ID,Name,Upline ID,Sponsor ID,Rank,Contatto,City,N diretti,N down,Extra,Image URL\r".Trim().ToUpper();
					else line += (char)b;
			}
			throw new Exception("codice non raggiungibile raggiunto");
		}

		public void CheckList()
		{
			for(int i = 0; i < tree.Count; ++i)
			{
				int n = 0;
				for(int j = 0; j < tree.Count; ++j)
				{
					if(i == j) continue;
					if(tree[i].id == tree[j].id) throw new Exception("Il file ha almeno un personal ID duplicato");
					if(tree[i].id == tree[j].uplineId)
					{
						++n;
						if(n == 3) throw new Exception($"ci sono tre downline all'id {tree[i].id}");
					}
				}
			}
		}

		/// <summary>
		/// va ad aggiungere tutte le informazioni senza controllare se sono già presenti
		/// </summary>
		public void CreaTreeFolder()
		{
			foreach(Persona item in tree)
			{
				if(item.name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
					throw new Exception($"Il nome in id:{item.id} ha caratteri non validi");

				string root = _treePath + "\\" + CreaPath(item);
				//Console.WriteLine(root);
				Directory.CreateDirectory(root);
				Byte[] info = new UTF8Encoding(true).GetBytes(item.ToString());
				using(FileStream fsw = new FileStream(Directory.GetParent(root).FullName + "\\" + item.name + "-details.txt", FileMode.CreateNew, FileAccess.Write, FileShare.None))
					fsw.Write(info, 0, info.Length);
			}
		}

		public string CreaPath(Persona item)
		{
			if(item.uplineId == -1)
				return item.name;

			//Persona upline = SearchItem(item.uplineId);
			//string parentPath = CreaPath(upline);

			return CreaPath(SearchItem(item.uplineId)) + $"\\{item.name}-{item.id}";
		}

		private Persona SearchItem(int id)
		{
			foreach(Persona item in tree)
				if(id == item.id) return item;
			throw new Exception($"id:{id} non trovato");
		}

	}
}
