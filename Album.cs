using System;
namespace MusicAlbumCollection
{
	public class Album
	{
		string name;
		int releaseYear;
		Artist artist;

		public string Name
		{
			get { return name; }
			set { 
					if (value == "")
					{
						name = "Unknown";
					}
					else {
						name = value;
					}
				}
		}

		public int ReleaseYear
		{
			get { return releaseYear; }
			set
			{
				if (value < 800 || value > 2030)
				{
					releaseYear = -1;
				}
				else {
					releaseYear = value;
				}
			}
		}

		public Artist Artist
		{
			get { return artist; }
			set { artist = value;}
		}

		public Album(Artist artistName, string albumName, int releaseYear)
		{
			Artist = artistName;
			Name = albumName;
			ReleaseYear = releaseYear;
		}

		public string GetAlbumInfo(){
			// Returns a string with info about the album
			string retString = "";
			retString += "";
			for (int i = 0; i < 5; i++) { retString += "* ";}
			retString += "Album Info";
			for (int i = 0; i < 5; i++) { retString += " *"; }
			retString += Environment.NewLine;
			retString += " Artist: " + Artist.Name + Environment.NewLine;
			retString += " Album:  " + name + Environment.NewLine;
			if (ReleaseYear == -1)
			{
				retString += " Year:   Unknown";
			} else {
				retString += " Year:   " + ReleaseYear;
			}
			retString += Environment.NewLine;
			for (int i = 0; i < 15; i++) { retString += "* "; }
			return retString ;
		}
	}
}
