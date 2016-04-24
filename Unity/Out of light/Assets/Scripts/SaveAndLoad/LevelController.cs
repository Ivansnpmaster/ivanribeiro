using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Scriptable object with levels")]
    public LevelHolder levelHolder;

	UIController uiController;

	public static LevelController instance;

	[HideInInspector] public MapGenerator mapGenerator;

    private void Awake()
    {
		instance = this;
        mapGenerator = FindObjectOfType<MapGenerator>();
		uiController = FindObjectOfType<UIController>();
    }

	#region In game generating level

	// In game generate level i.e. Load a level
	public void GenerateNextLevel()
	{
		Level level = levelHolder.GetLastIdUncompletedLevel();
		
		if(Application.loadedLevelName != "Level editor")
		{
			
			uiController.ChangeLevelName(level.levelName);
		}
		
		mapGenerator.StartCoroutine("GenerateLevel", level);
	}
	
	public void CheckLevelCompleted()
	{
		if (mapGenerator.CheckLevelCompleted())
		{
			string lastLevel = levelHolder.GetLastIdUncompletedLevel().levelName;
			Utility.SetKeyComplete(lastLevel.Substring(lastLevel.Length - 1, 1));
			GenerateNextLevel();
		}
	}

	#endregion
}