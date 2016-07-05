using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Utility
{
    public static List<Color> colors = new List<Color>()
    {
        Color.black,
        Color.white,
        Color.green,
        Color.red,
        Color.blue,
        Color.cyan,
        Color.gray,
        Color.magenta,
        Color.yellow
    };

    public static float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    public static Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

    public static Color GetRandomColor(Color index)
    {
        Color newColor = colors[Random.Range(0, colors.Count)];

        while (newColor == index)
            newColor = colors[Random.Range(0, colors.Count)];

        return newColor;
    }

	#region Playerprefs stuff

	public static void DebugAllLevels()
	{
		int c = LevelController.instance.levelHolder.levels.Count;

		for (int i = 0; i < c; i++)
		{
			if (PlayerPrefs.HasKey("Level " + (i + 1)))
				Debug.Log("Level completo: " + PlayerPrefs.GetInt("Level " + (i + 1)));
		}
	}
	
	public static void SetKeyComplete(string name)
	{
		PlayerPrefs.SetInt("Level " + name, int.Parse(name) - 1);
	}
	
	public static void DeleteAllLevelKeys()
	{
		int c = LevelController.instance.levelHolder.levels.Count;

		for (int i = 0; i < c; i++)
		{
			if (PlayerPrefs.HasKey("Level " + (i + 1)))
			{
				PlayerPrefs.DeleteKey("Level " + (i + 1));
				Debug.Log("Key deleted: " + "Level " + (i + 1));
			}
		}

		Debug.Log("All level keys are gone!");
	}

	#endregion
}