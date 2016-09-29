using System;
namespace MusicAlbumCollection
{
	public class Album
	{
		int id;
		string name;
		int releaseYear;
		string artist;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

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

		public string Artist
		{
			get { return artist; }
			set 
				{ 
					if(value == "")
					{
						artist = "Unknown";
					} else {
						artist = value;
					}
				}
		}

		public Album(string artistName, string albumName, int releaseYear)
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
			retString += " Id:     " + Id + Environment.NewLine;
			retString += " Artist: " + Artist + Environment.NewLine;
			retString += " Album:  " + Name + Environment.NewLine;
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
