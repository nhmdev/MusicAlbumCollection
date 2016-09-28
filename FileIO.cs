using System;
namespace MusicAlbumCollection
{
	public class FileIO
	{
		string fileName;

		public string FileName {
			get { return fileName;}
		}

		public FileIO(string fileName)
		{
			// Check and set filename
			if (fileName == "")
			{
				this.fileName = "MusicAlbumCollection.csv";
			} else {
				this.fileName = fileName;
			}

		}
	}
}
