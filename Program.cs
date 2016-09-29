using System;
//using System.Collections.Generic;

namespace MusicAlbumCollection
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//List<Album> albums = new List<Album>();
			Collection albumCollection = new Collection("My Album Collection");

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
						foreach(string albuminfo in albumCollection.GetAlbumsInfo()){
							Console.WriteLine(albuminfo);
						}
						//Console.WriteLine(albumCollection.GetAlbumsInfo());
						Console.WriteLine("****************************");
						break;
					case 2:
						// Create new album and add it to the albums list
						Console.Clear();
						Console.WriteLine("Adding new album to memory");
						Console.WriteLine("**************************");
						albumCollection.AddAlbum(CreateAlbum());
						Console.WriteLine("**************************");
						Console.WriteLine();
						break;
					case 3:
						// Edit album
						Console.Clear();
						Console.WriteLine("Editing existing album in memory");
						Console.WriteLine("********************************");
						EditAlbum(albumCollection);
						Console.WriteLine("********************************");
						Console.WriteLine();
						break;

					case 4:
						// Delete album
						Console.Clear();
						Console.WriteLine("Delete existing album in memory");
						Console.WriteLine("*******************************");
						DeleteAlbum(albumCollection);
						Console.WriteLine("*******************************");
						Console.WriteLine();
						break;

					case 5:
						// Load album
						Console.Clear();
						Console.WriteLine("Loading existing albums from file");
						Console.WriteLine("*********************************");
						Console.Write("Filename to load (Without extension): ");
						string loadFilename = Console.ReadLine();
						if(albumCollection.LoadFromFile(loadFilename)){
							Console.WriteLine("Loaded from file " + loadFilename + ".csv");
						} else {
							Console.WriteLine("Could not load any albums");
						}
						Console.WriteLine("*********************************");
						Console.WriteLine();
						break;
						
					case 6:
						// Save album
						Console.Clear();
						Console.WriteLine("Saving existing album to file");
						Console.WriteLine("*****************************");
						Console.Write("Choose a filename (without extension): ");
						string saveFilename = Console.ReadLine();
						albumCollection.SaveToFile(saveFilename);
						Console.WriteLine("Saved to file " + saveFilename + ".csv");
						Console.WriteLine("*****************************");
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

		public static Album GetAlbum(Collection albumCollection){
			Console.Write("Enter id of the album: ");
			string input = Console.ReadLine();
			int inputAsInt;
			while(!(int.TryParse(input, out inputAsInt)))
			{
				Console.WriteLine("You did not choose a number. Try again");
				Console.Write("Enter id of the album: ");
				input = Console.ReadLine();
			}
			if(albumCollection.CheckAlbumIdExists(inputAsInt)){
				 return albumCollection.GetAlbum(inputAsInt);
			} else {
				Console.WriteLine("Album with that id does not exist. Returning empty album.");
				return new Album("","",0);
			}

		}

		public static bool EditAlbum(Collection albumCollection) {
			Console.Write("Enter id of the album: ");
			string input = Console.ReadLine();
			int inputAsInt;
			while (!(int.TryParse(input, out inputAsInt)))
			{
				Console.WriteLine("You did not choose a number. Try again");
				Console.Write("Enter id of the album: ");
				input = Console.ReadLine();
			}
			if(albumCollection.CheckAlbumIdExists(inputAsInt)){
				Album existingAlbum = albumCollection.GetAlbum(inputAsInt);

				Console.Write("Artist ( " + existingAlbum.Artist + " ): ");
				string newArtist = Console.ReadLine();
				if (newArtist == "") newArtist = existingAlbum.Artist;
				Console.Write("Album ( " + existingAlbum.Name + " ): ");
				string newAlbum = Console.ReadLine();
				if (newAlbum == "") newAlbum = existingAlbum.Name;
				Console.Write("Year ( " + existingAlbum.ReleaseYear + " ): ");
				string newYear = Console.ReadLine();
				if (newYear == "") newYear = existingAlbum.ReleaseYear.ToString();

				// Try parse input year as a int and save to yearAsInt
				int newYearAsInt;
				while (!(int.TryParse(newYear, out newYearAsInt)))
				{
					Console.WriteLine("Year is not a number. Try again. Year: ");
					newYear = Console.ReadLine();
				}

				if(albumCollection.EditAlbum(inputAsInt, newArtist, newAlbum, newYearAsInt)){
					return true;
				} else {
					Console.WriteLine("Could not save changes.");
					return false;
				}
			} else {
				Console.WriteLine("Album id does not exist. Nothing changed.");
				return false;
			}
		}

		public static bool DeleteAlbum(Collection albumCollection) {
			Console.Write("Enter id of the album: ");
			string input = Console.ReadLine();
			int inputAsInt;
			while (!(int.TryParse(input, out inputAsInt)))
			{
				Console.WriteLine("You did not choose a number. Try again");
				Console.Write("Enter id of the album: ");
				input = Console.ReadLine();
			}
			if (albumCollection.CheckAlbumIdExists(inputAsInt))
			{
				Album album = albumCollection.GetAlbum(inputAsInt);
				Console.WriteLine(album.GetAlbumInfo());
				Console.WriteLine("Is this correct album to delete? (Y/N)");
				string input2 = Console.ReadLine();
				while(!( (input2.ToUpper() == "Y") || input2.ToUpper() == "N")){
					Console.WriteLine("Choose Y or N: ");
					input2 = Console.ReadLine();
				}
				if(input2.ToUpper() == "Y"){
					albumCollection.DeleteAlbum(inputAsInt);
					Console.WriteLine("Deleted the album");
					return true;
				} else {
					Console.WriteLine("Nothing deleted");
					return false;
				}
			} else {
				Console.WriteLine("Could not find the album id");
				return false;
			}
		}
	}
}
