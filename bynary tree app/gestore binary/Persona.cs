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
		public string extra;
		public string imageUrl;

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
			this.extra = extra;
			this.imageUrl = imageUrl;
		}

		public override string ToString()
		{
			return this.ToString("\n");
		}
		public string ToString(string sep)
		{
			return $"id:{id}{sep}name:{name}{sep}uplineId:{uplineId}{sep}sponsorId:{sponsorId}{sep}rank:{rank}{sep}contatto:{contatto}{sep}city:{city}{sep}nDiretti:{nDiretti}{sep}nDown:{nDown}{sep}extra:{extra}{sep}imageUrl:{imageUrl}";
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
