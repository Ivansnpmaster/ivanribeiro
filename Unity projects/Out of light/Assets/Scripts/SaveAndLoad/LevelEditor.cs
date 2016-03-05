using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelEditor : MonoBehaviour
{
    string levelToLoad = string.Empty;

	MapGenerator mapGenerator;

	void Awake()
	{
		mapGenerator = FindObjectOfType<MapGenerator>();
	}

    public void SetLevelToLoadString(string level)
    {
        levelToLoad = level;
    }

	public InputField inputField;

	public void LoadLevelX()
	{
		levelToLoad = inputField.text;

		if (levelToLoad != "" || levelToLoad != string.Empty)
		{
			Level lv = SaveAndLoad.instance.LoadLevel(levelToLoad);
			mapGenerator.StartCoroutine("GenerateLevel", lv);
		}
	}

	public void ClearLevel()
	{
		int xTo = mapGenerator.lights.GetLength(0);
		int yTo = mapGenerator.lights.GetLength(1);

		for (int x = 0; x < xTo; x ++)
		{
			for (int y = 0; y < yTo; y ++)
			{
				if (mapGenerator.lights[x, y].isOn)
					mapGenerator.lights[x, y].Turn();
			}
		}
	}

	public void SaveLevel()
	{
		string pairs = "";

		int xTo = mapGenerator.lights.GetLength(0);
		int yTo = mapGenerator.lights.GetLength(1);
		
		for (int x = 0; x < xTo; x ++)
		{
			for (int y = 0; y < yTo; y ++)
			{
				if (mapGenerator.lights[x, y].isOn)
					pairs += "-" + x + "," + y;
			}
		}

		string levelName = (SaveAndLoad.instance.GetLastLevel() + 1).ToString();

		SaveAndLoad.instance.SaveLevel(new Level(levelName, pairs, xTo, yTo));
	}
}