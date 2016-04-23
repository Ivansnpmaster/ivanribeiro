using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
	[Header("Scriptable object with levels")]
	public LevelHolder levelHolder;

	MapGenerator mapGenerator;

	private void Awake()
	{
		mapGenerator = FindObjectOfType<MapGenerator>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Generate");
			GenerateNextLevel();
		}
	}

	// Editor save level function
	public void SaveLevel(Level current)
	{
		levelHolder.levels.Add(current);
	}

	// In game generate level i.e. Load a level
	public void GenerateNextLevel()
	{
		Level level = levelHolder.GetLastUncompletedLevel();
		mapGenerator.StartCoroutine("GenerateLevel", level);
	}
}