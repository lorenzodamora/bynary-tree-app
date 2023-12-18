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
			try
			{
				FilePath = filePath;
				TreePath = treePath;
				LoadFile();
				CheckList();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void LoadFile()
		{
			if(!CheckHeaderFile()) throw new ArgumentException("Il file csv inserito ha head scorretto");
			string[] lines = File.ReadAllLines(_csvPath);
			tree.Clear();
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
					puntiPosseduti = int.Parse(split[9]),
					puntiGenerati = int.Parse(split[10]),
					extra = split[11],
					imageUrl = split[12]
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
						return line.Trim().ToUpper() == Persona.Head.Trim().ToUpper();
					else line += (char)b;
			}
			//throw new Exception("codice non raggiungibile raggiunto");
			return false;
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
				Byte[] info = new UTF8Encoding(true).GetBytes(item.ToString() + "\r\n");
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

		public void CreaTreeFile()
		{
			var dir = new DirectoryInfo(_treePath);
			if(!dir.Exists)
				throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

			string[] GetFilesRecursive(string folderPath)
			{
				try
				{
					return Directory.GetFiles(folderPath, "*.txt", SearchOption.AllDirectories);
				}
				catch(Exception ex)
				{
					throw new Exception($"Errore durante la scansione delle cartelle: {ex.Message}");
				}
			}
			using(FileStream fs = new FileStream(_csvPath, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				string str = Persona.Head + "\r\n";
				Byte[] info = new UTF8Encoding(true).GetBytes(str);
				fs.Write(info, 0, info.Length);

				string[] allFiles = GetFilesRecursive(_treePath);
				List<string> allLines = new List<string>();
				foreach(string file in allFiles)
				{
					allLines.Add(File.ReadAllText(file));
					string[] strs = File.ReadAllText(file).Split('\n');
					for(int i = 0; i < strs.Length; i++)
					{
						str = strs[i];
						if(str.Length != 0)
							str = str.Remove(str.Length - 1);
						// Rimuovi il testo prima dei due punti ":"
						int ind = str.IndexOf(':');
						if(ind != -1) strs[i] = str.Substring(ind + 1);
					}
					str = string.Join(",", strs);
					info = new UTF8Encoding(true).GetBytes(str + "\r\n");
					fs.Write(info, 0, info.Length);
				}
			}
			LoadFile();
			CheckList();
		}

		/// <summary>
		/// basati sul file csv già listato, che va ad aggiornare solo il csv stesso
		/// </summary>
		public void Calcoli()
		{
			for(int i = 0; i < tree.Count; ++i)
			{
				tree[i].nDiretti = -1;
				tree[i].nDown = -1;
				tree[i].puntiPosseduti = -1;
			}

			//ndown
			for(int i = 0; i < tree.Count; ++i)
			{
				if(tree[i].nDown == -1)
					tree[i].nDown = CalcolaNdown(tree[i].id);
				if(tree[i].puntiPosseduti == -1)
					tree[i].puntiPosseduti = CalcolaPPosseduti(tree[i].id);
				if(tree[i].nDiretti == -1)
					tree[i].nDiretti = CalcolaNdiretti(tree[i].id);
			}

			// Funzione ricorsiva per calcolare il numero di discendenti di una persona
			int CalcolaNdown(int id)
			{
				int count = 0;
				foreach(var p in tree)
					if(p.uplineId == id)
						count += 1 + CalcolaNdown(p.id);
				return count;
			}

			// Funzione ricorsiva per calcolare i punti generati di una persona
			float CalcolaPPosseduti(int id)
			{
				float point = 0;
				foreach(var p in tree)
					if(p.uplineId == id)
						point += p.puntiGenerati + CalcolaPPosseduti(p.id);
				return point;
			}

			int CalcolaNdiretti(int id)
			{
				int count = 0;
				foreach(var p in tree)
					if(p.sponsorId == id)
						++count;
				return count;
			}

			StampaNuovoCsv();

		}

		public void StampaNuovoCsv()
		{
			using(FileStream fs = new FileStream(_csvPath, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				string str = Persona.Head + "\r\n";
				Byte[] info = new UTF8Encoding(true).GetBytes(str);
				fs.Write(info, 0, info.Length);
				foreach(var p in tree)
				{
					str = p.ToString(",", false);
					info = new UTF8Encoding(true).GetBytes(str + "\r\n");
					fs.Write(info, 0, info.Length);
				}
			}
		}

		public void SortFile()
		{
			List<Persona> QuickSort(List<Persona> arr, int lxInd, int rxInd)
			{
				var i = lxInd;
				var j = rxInd;
				var pivot = arr[lxInd].id;

				while(i <= j)
				{
					while(arr[i].id < pivot)
						i++;

					while(arr[j].id > pivot)
						j--;

					if(i <= j)

						(arr[j], arr[i])=(arr[i++], arr[j--]);
				}

				if(lxInd < j)
					QuickSort(arr, lxInd, j);

				if(i < rxInd)
					QuickSort(arr, i, rxInd);

				return arr;
			}

			tree = QuickSort(new List<Persona>(tree), 0, tree.Count - 1);

			StampaNuovoCsv();
		}

		/// <summary>
		/// va ad aggiornare solo il csv.
		/// </summary>
		public void ResetPunti()
		{
			foreach(var p in tree)
			{
				p.puntiPosseduti = p.puntiGenerati = 0;
			}
			StampaNuovoCsv();
		}
	}
}
