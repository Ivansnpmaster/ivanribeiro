using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Level
{
    public string levelName = "Level ";
    public int x;
    public int y;
    public string activeLights = "";

    public float timeToSpawn;

    public Level(string _levelName, int _x, int _y, string _activeLights, float _timeToSpawn)
    {
        levelName += _levelName;
        x = _x;
        y = _y;
        activeLights = _activeLights;
        timeToSpawn = _timeToSpawn;
    }
}

[CreateAssetMenu(fileName = "New Level Holder Data", menuName = "Level Holder", order = 1)]
public class LevelHolder : ScriptableObject
{
    public List<Level> levels;

	public Level GetLastIdUncompletedLevel()
	{
		int lastId = 0;

		for (int i = 0; i < levels.Count; i++)
		{
			if (PlayerPrefs.HasKey("Level " + (i + 1)))
				lastId = i + 1;
		}

		if (lastId >= levels.Count)
			lastId = 0;

		return levels[lastId];
	}
}