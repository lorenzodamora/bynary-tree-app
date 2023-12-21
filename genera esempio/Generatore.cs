using System;
using System.IO;
using System.Text;

namespace genera_esempio
{
	internal class Generatore
	{
		static void Main()
		{
			Console.WriteLine("inserisci path file:");
			string file = Console.ReadLine().Trim().Trim('"');

			string text = "Personal ID,Name,Upline ID,Sponsor ID,Rank,Contatto,City,N diretti,N down,Punti Posseduti,Punti Generati,Extra,Image URL\r\n" +
				"0,Lore,-1,-1,None, damora.lorenzo.zero@gmail.com +39 328 643 5255,Bergamo Torre Boldone,0,2,0,0,,https://drive.google.com/file/d/1mzIYSKSLCGYL6Cn5AfjE6lgXAqjSsJLr/view?usp=sharing,\r\n" +
				"1,uno,0,0,-,mail e o numero,c,2,14,4400,0,,\r\n" +
				"2,due,0,0,-,mail e o numero,c,2,14,4400,0,,\r\n" +
				"3,tre,1,1,-,mail e o numero,c,2,6,2200,0,,\r\n" +
				"4,quattro,1,1,-,mail e o numero,c,2,6,2200,0,,\r\n" +
				"5,cinque,2,2,-,mail e o numero,c,2,6,2200,0,,\r\n" +
				"6,sei,2,2,-,mail e o numero,c,2,6,2200,0,,\r\n" +
				"7,sette,3,3,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"8,otto,3,3,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"9,nove,4,4,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"10,dieci,4,4,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"11,undici,5,5,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"12,dodici,5,5,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"13,tredici,6,6,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"14,quattordici,6,6,-,mail e o numero,c,2,2,1100,0,,\r\n" +
				"15,quindici,7,7,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"16,sedici,7,7,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"17,diciassette,8,8,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"18,diciotto,8,8,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"19,diciannove,9,9,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"20,venti,9,9,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"21,ventuno,10,10,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"22,ventidue,10,10,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"23,ventitre,11,11,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"24,ventiquattro,11,11,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"25,venticinque,12,12,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"26,ventisei,12,12,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"27,ventisette,13,13,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"28,ventotto,13,13,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"29,ventinove,14,14,-,mail e o numero,c,0,0,0,550,,\r\n" +
				"30,trenta,14,14,-,mail e o numero,c,0,0,0,550,,\r\n";

			using(var fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				Byte[] info = new UTF8Encoding(true).GetBytes(text);
				fs.Write(info, 0, info.Length);
			}
		}
	}
}
