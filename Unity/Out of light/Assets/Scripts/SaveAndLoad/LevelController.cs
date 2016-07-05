using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Scriptable object with levels")]
    public LevelHolder levelHolder;

	//UIController uiController;

	public static LevelController instance;

	[HideInInspector] public MapGenerator mapGenerator;

    private void Awake()
    {
		instance = this;
        mapGenerator = FindObjectOfType<MapGenerator>();
		//uiController = FindObjectOfType<UIController>();
    }

	#region In game generating level

	// In game generate level i.e. Load a level
	public void GenerateNextLevel(Level level)
	{

#if !UNITY_EDITOR
		if(Application.loadedLevelName != "Level editor")
			uiController.ChangeLevelName(level.levelName);
#endif

		mapGenerator.StartCoroutine("GenerateLevel", level);
	}

	public void GenerateNextLevel()
	{
		Level level = levelHolder.GetLastIdUncompletedLevel();

		#if !UNITY_EDITOR
		if(Application.loadedLevelName != "Level editor")
			uiController.ChangeLevelName(level.levelName);
		#endif
		
		mapGenerator.StartCoroutine("GenerateLevel", level);
	}
	
	public void CheckLevelCompleted()
	{
		if (mapGenerator.CheckLevelCompleted())
		{
			Utility.SetKeyComplete(mapGenerator.CurrentLevel.levelName.Substring(mapGenerator.CurrentLevel.levelName.Length - 1, 1));
			Level level = levelHolder.GetLastIdUncompletedLevel();
			GenerateNextLevel(level);
		}
	}

	#endregion
}