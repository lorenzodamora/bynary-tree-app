using System;

namespace bynary_tree_app
{
	internal struct Persona
	{
		public int id;
		public string name;
		public int uplineId;
		public int sponsorId;
		public Rank rank;
		public string contatto;
		public string city;
		public int nDiretti;
		public int nDown;
		public string imageUrl;

		public Persona(
			int id,
			string name,
			int uplineId,
			int sponsorId,
			Rank rank,
			string contatto,
			string city,
			int nDiretti,
			int nDown,
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
			this.imageUrl = imageUrl;
		}
	}

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
}
