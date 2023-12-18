namespace bynary_tree_app
{
	internal class Persona
	{
		public int id;
		public string name;
		public int uplineId;
		public int sponsorId;
		public string rank;
		public string contatto;
		public string city;
		public int nDiretti;
		public int nDown;
		public float puntiPosseduti;
		public float puntiGenerati;
		public string extra;
		public string imageUrl;

		static public string Head => "Personal ID,Name,Upline ID,Sponsor ID,Rank,Contatto,City,N diretti,N down,Punti Posseduti,Punti Generati,Extra,Image URL";
		public Persona() { }

		public Persona(
			int id,
			string name,
			int uplineId,
			int sponsorId,
			string rank,
			string contatto,
			string city,
			int nDiretti,
			int nDown,
			float pPosseduti,
			float pGenerati,
			string extra,
			string imageUrl)
		{
			this.id = id;
			this.name = name;
			this.uplineId = uplineId;
			this.sponsorId = sponsorId;
			this.rank = rank;
			this.contatto = contatto;
			this.city = city;
			this.nDiretti = nDiretti;
			this.nDown = nDown;
			this.puntiPosseduti = pPosseduti;
			this.puntiGenerati = pGenerati;
			this.extra = extra;
			this.imageUrl = imageUrl;
		}

		public override string ToString() => ToString("\r\n", true);

		public string ToString(string sep, bool descrizione)
		{
			if(descrizione)
			return $"id:{id}{sep}name:{name}{sep}uplineId:{uplineId}{sep}sponsorId:{sponsorId}{sep}rank:{rank}{sep}contatto:{contatto}{sep}city:{city}{sep}nDiretti:{nDiretti}{sep}nDown:{nDown}{sep}puntiPosseduti:{puntiPosseduti}{sep}puntiGenerati:{puntiGenerati}{sep}extra:{extra}{sep}imageUrl:{imageUrl}";
			return $"{id}{sep}{name}{sep}{uplineId}{sep}{sponsorId}{sep}{rank}{sep}{contatto}{sep}{city}{sep}{nDiretti}{sep}{nDown}{sep}{puntiPosseduti}{sep}{puntiGenerati}{sep}{extra}{sep}{imageUrl}";
		}
	}
	/*
	internal enum Rank
	{
		None = 0,
		Star = 1,
		Consultant = 2,
		Zapphire = 3,
		Ruby = 4,
		Hemerald = 5,
		Diamond = 6
	}
	*/
}
