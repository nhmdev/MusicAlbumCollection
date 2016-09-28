using System;
using System.Collections.Generic;

namespace MusicAlbumCollection
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Album> albums = new List<Album>();
			bool runMenu = true;
			while (runMenu)
			{
				switch (Menu())
				{
					case 0:
						// Quit
						runMenu = false;
						break;
					case 1:
						// List albums
						Console.Clear();
						Console.WriteLine("Listing all albums in memory");
						Console.WriteLine("****************************");
						foreach (Album album in albums)
						{
							Console.WriteLine(album.GetAlbumInfo());
						}
						Console.WriteLine("****************************");
						break;
					case 2:
						// Create new album and add it to the albums list
						Console.Clear();
						Console.WriteLine("Adding new album to memory");
						Console.WriteLine("**************************");
						albums.Add(CreateAlbum());
						Console.WriteLine("**************************");
						Console.WriteLine();
						break;
				}

			}
			 
			/*
			Console.WriteLine("Number of albums in file: " + file.CountAlbumsInFile());

			Album album1 = new Album("Andrew W.K", "I Get Wet", 2001);
			albums.Add(album1);

			Album album2 = new Album("", "", 32);
			albums.Add(album2);

			Console.WriteLine(album1.GetAlbumInfo() + Environment.NewLine);
			Console.WriteLine(album2.GetAlbumInfo());

			file.Save(albums);
			Console.WriteLine("Number of albums in file: " + file.CountAlbumsInFile());
*/
		}

		static int Menu(){
			int highestChoice = 6; // Change to the highest choice avaible
			string input; // A string variable for user input
			int inputAsInt; // A int variable for user input

			// Write all menu choices
			Console.WriteLine("***** Menu *****");
			Console.WriteLine("0. Quit");
			Console.WriteLine("1. List albums");
			Console.WriteLine("2. Create new album");
			Console.WriteLine("3. Edit album");
			Console.WriteLine("4. Delete album");
			Console.WriteLine("5. Load albums from file");
			Console.WriteLine("6. Save albums to file");
			Console.WriteLine("Choose a number: ");
			// Read input from user
			input = Console.ReadLine();

			// Try parse input as a int and save to inputAsInt
			if(int.TryParse(input, out inputAsInt) == false){
				// If not able to parse as a int then set -1
				inputAsInt = -1;
			}

			// If user input is not betweeen 0 and highest choice ask user again
			while(!((inputAsInt >= 0) && (inputAsInt <= highestChoice)))
			{
				Console.WriteLine("Not a valid choice. Try again. Choose a number: ");
				input = Console.ReadLine();

				if (int.TryParse(input, out inputAsInt) == false)
				{
					// If not able to parse as a int then set -1
					inputAsInt = -1;
				}
			}
			// Return the input
			return inputAsInt;
		}

		public static Album CreateAlbum(){
			Console.Write("Artist: ");
			string artist = Console.ReadLine();
			Console.Write("Album: ");
			string album = Console.ReadLine();
			Console.Write("Year: ");
			string year = Console.ReadLine();

			// Try parse input year as a int and save to yearAsInt
			int yearAsInt;
			if (!(int.TryParse(year, out yearAsInt)))
			{
				// If not able to parse as a int then set -1
				yearAsInt = -1;
				Console.WriteLine("Year is not a number. Setting year to -1");
			}

			// Create and return Album object
			return new Album(artist, album, yearAsInt);
		}
	}
}
