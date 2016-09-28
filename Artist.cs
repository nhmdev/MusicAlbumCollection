using System;
namespace MusicAlbumCollection
{
	public class Artist
	{
		string name;

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public Artist(string artistName)
		{
			name = artistName;
		}


	}
}
