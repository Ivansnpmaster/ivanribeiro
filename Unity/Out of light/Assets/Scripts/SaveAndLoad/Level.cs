using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Level
{
    public string levelName = "Level ";
    public int x;
    public int y;
    public bool completed = false;
    public string activeLights = "";

    public float timeToSpawn;

    public Level(string _levelName, int _x, int _y, bool _completed, string _activeLights, float _timeToSpawn)
    {
        levelName += _levelName;
        x = _x;
        y = _y;
        completed = _completed;
        activeLights = _activeLights;
        timeToSpawn = _timeToSpawn;
    }
}

[CreateAssetMenu(fileName = "New Level Holder Data", menuName = "Level Holder", order = 1)]
public class LevelHolder : ScriptableObject
{
    public List<Level> levels;

    public Level GetLastUncompletedLevel()
    {
        int firstUncompletedIndex = 0;
		int levelsCount = levels.Count;

		for (int i = 0; i < levelsCount; i++)
        {
            if (!levels[i].completed)
            {
                firstUncompletedIndex = i;
                break;
            }
        }
        return levels[firstUncompletedIndex];
    }
}