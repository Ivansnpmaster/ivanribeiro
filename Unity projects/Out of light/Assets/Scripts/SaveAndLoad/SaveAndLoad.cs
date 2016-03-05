using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
	public static SaveAndLoad instance;
	
	public static List<Level> levels = new List<Level>();
	
	const string path = "/Game level/";

	private void Awake()
	{
		instance = this;
		Load();
	}

	public void SaveLevel(Level newLevel)
	{
		levels.Add(newLevel);

		for (int i = 0; i < levels.Count; i ++)
		{
			if (File.Exists(Application.persistentDataPath  + path + string.Format("/Level - {0}.snp", levels[i].name)))
				File.Delete(Application.persistentDataPath  + path + string.Format("/Level - {0}.snp", levels[i].name));
		}

		Save ();
	}

	public void Save()
	{
		if (Directory.Exists(Application.persistentDataPath + path))
			Directory.CreateDirectory(Application.persistentDataPath + path);

		foreach (Level l in levels)
		{
			BinaryFormatter binary = new BinaryFormatter();
			FileStream fS = File.Create(Application.persistentDataPath  + path + string.Format("/Level - {0}.snp", l.name));
			
			binary.Serialize(fS, l);
			fS.Close();
		}
	}

	public void Load()
	{
		if (!Directory.Exists(Application.persistentDataPath + path))
			Directory.CreateDirectory(Application.persistentDataPath + path);

		foreach (string f in Directory.GetFiles(Application.persistentDataPath + path, "*.snp"))
		{
			BinaryFormatter binary = new BinaryFormatter();
			FileStream fS = File.Open(f, FileMode.Open);

			Level lv = binary.Deserialize(fS) as Level;

			levels.Add(lv);
			fS.Close();
		}
	}

	public Level LoadLevel (string levelToLoad)
	{
		if (File.Exists(Directory.GetFiles(Application.persistentDataPath + path, string.Format("Level - {0}.snp", levelToLoad))[0]))
		{
			string filePath = Directory.GetFiles(Application.persistentDataPath + path, string.Format("Level - {0}.snp", levelToLoad))[0];

			BinaryFormatter binary = new BinaryFormatter();
			FileStream fS = File.Open(filePath, FileMode.Open);
			
			Level lv = binary.Deserialize(fS) as Level;
		
			if (!levels.Contains(lv))
				levels.Add(lv);

			fS.Close();

			return lv;
		}

		return levels[0];
	}

	public int GetLastLevel ()
	{
		return levels.Count;
	}
}


[System.Serializable]
public class Level
{
	[SerializeField] public string name;
	[SerializeField] public string activeLights;
	[SerializeField] public int x;
	[SerializeField] public int y;

	public Level(string newName, string lights, int newX, int newY)
	{
		name = newName;
		activeLights = lights;
		x = newX;
		y = newY;
	}
}