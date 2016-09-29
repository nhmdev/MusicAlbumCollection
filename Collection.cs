using System;
using System.Collections.Generic;
namespace MusicAlbumCollection
{
	public class Collection
	{
		string name;
		List<Album> albums = new List<Album>();
		int idIndex = 1;

		public string Name
		{
			get { return name; }
			set
			{
				if (value == "")
				{
					name = "Unnamed Collection";
				}
				else {
					name = value;
				}
			}
		}

		public Collection(string name)
		{
			this.Name = name;
		}

		public void AddAlbum(Album album){
			album.Id = idIndex;
			albums.Add(album);
			idIndex++;
		}

		public Album GetAlbum(int id)
		{
			int index = albums.FindIndex(obj => obj.Id == id);
			return albums[index];
		}

		public int GetAlbumCount()
		{
			return albums.Count;
		}

		public string[] GetAlbumsInfo()
		{
			string[] retString = new string[GetAlbumCount()];
			int index = 0;
			foreach (Album album in albums)
			{
				retString[index] = album.GetAlbumInfo();
				index++;
			}
			return retString;
		}

		public bool CheckAlbumIdExists(int id)
		{
			int index = albums.FindIndex(obj => obj.Id == id);
			if (index == -1)
			{
				return false;
			}
			else {
				return true;
			}
		}

		public bool EditAlbum(int id, string artist, string album, int year) {
			if (CheckAlbumIdExists(id))
			{
				albums[FindAlbumIndex(id)].Artist = artist;
				albums[FindAlbumIndex(id)].Name = album;
				albums[FindAlbumIndex(id)].ReleaseYear = year;
				return true;
			} else {
				return false;
			}
		}

		public void DeleteAlbum(int id){
			int index = albums.FindIndex(obj => obj.Id == id);
			albums.RemoveAt(index);
		}

		int FindAlbumIndex(int id){
			return albums.FindIndex(c => c.Id == id);
		}

		public bool SaveToFile(string filename){
			FileIO file = new FileIO(filename);
			file.Save(albums);
			return true;
		}

		public bool LoadFromFile(string filename){
			FileIO file = new FileIO(filename);
			if(file.CountAlbumsInFile() > 0){
				albums = file.Load();
				idIndex = albums.Count + 1;
				return true;
			} else {
				return false;
			}

		}



	}
}
