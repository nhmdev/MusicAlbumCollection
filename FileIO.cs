using System;
using System.Collections.Generic;
using System.IO;
namespace MusicAlbumCollection
{
	public class FileIO
	{
		string fileName;
		char delimiter = ';';


		public FileIO(string fileName)
		{
			
			// Check and set filename
			if (fileName == "")
			{
				// If fileName is empty then set default name
				this.fileName   = "MusicAlbumCollection.csv";
			} else {
				// Add .csv extension to fileName
				this.fileName = fileName + ".csv";
			}
		}

		public int CountAlbumsInFile(){
			try
			{
				return File.ReadAllLines(fileName).Length;
			}
			catch{
				return 0;
			}
		}

		public List<Album> Load(){
			List<Album> albums = new List<Album>();

			if(File.Exists(fileName)){
				// Using ReadLines because its more efficient than ReadAllLines when bigger files.
				foreach (string line in File.ReadLines(fileName))
				{
					string[] splittedLine = line.Split(delimiter);
					if (splittedLine.Length == 3)
					{   // Makes sure the line consists of 3 elements
						string artistName = splittedLine[0];
						string albumName = splittedLine[1];
						int year;
						if (!(int.TryParse(splittedLine[2], out year)))
						{
							// Try to parse year string to int. Else set year to following:
							year = -1;
						}
						// Create Album object
						Album album = new Album(artistName, albumName, year);

						// Insert object to list
						albums.Add(album);
					}
				}
			}
			return albums;
		}

		public void Save(List<Album> albums){

			List<string> lines = new List<string>();

			// Foreach album make a line
			foreach(Album album in albums){
				lines.Add(album.Artist + delimiter + 
				          album.Name + delimiter + 
				          album.ReleaseYear.ToString()
				         );
			}

			// Write lines to file

			File.WriteAllLines(fileName, lines);
		}

	}
}
