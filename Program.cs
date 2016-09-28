using System;

namespace MusicAlbumCollection
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Artist artist1 = new Artist("Andrew W.K");
			Album album1 = new Album(artist1, "I Get Wet", 2001);
			Album album2 = new Album(artist1, "", 32);
			Console.WriteLine(album1.GetAlbumInfo() + Environment.NewLine);
			Console.WriteLine(album2.GetAlbumInfo());
		}
	}
}
