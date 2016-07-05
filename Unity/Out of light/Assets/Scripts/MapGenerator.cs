using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
	CameraAnimation camAnim;

	public Level CurrentLevel {get {return currentLevel;} set {currentLevel = value;}}

	public PointOfLight lightPrefab;
	Level currentLevel;
	PointOfLight[,] lightPoints;
	Vector3 bottomPoint = Vector2.zero;
	Color fromColor;
	Color to;

	private void Awake()
	{
		camAnim = Camera.main.GetComponent<CameraAnimation> ();
	}

    #region In game generating map

	public IEnumerator GenerateLevel(Level level)
	{
		CurrentLevel = level;

		camAnim.StartCoroutine ("Animate");

		if (GameObject.Find ("Lights holder"))
			GameObject.Destroy (GameObject.Find ("Lights holder"));

		GameObject father = new GameObject ("Lights holder");

		lightPoints = new PointOfLight[level.x, level.y];

		fromColor = Utility.GetRandomColor ();
		to = Utility.GetRandomColor (fromColor);

		bottomPoint = new Vector3 (-level.x / 2F, -level.y / 2F, 0F);
		Vector2 maxMatrix = new Vector2 (level.x, level.y);

		for (int i = 0; i < CurrentLevel.x; i++)
			for (int j = 0; j < CurrentLevel.y; j++)
			{
					Vector3 point = new Vector3 (i + bottomPoint.x, j + bottomPoint.y, 0F);
					string lightName = "X: " + i + " Y:" + j;
					float colorPercent = ((i / maxMatrix.x) + (j / maxMatrix.y)) * .5F;
					Color c = Color.Lerp (fromColor, to, colorPercent);
					BlockType bT = GetBlockType(i, j);
					print(bT);
					
					PointOfLight pointOfLight = Instantiate(lightPrefab, point, lightPrefab.transform.rotation) as PointOfLight;
					pointOfLight.Initialize(bT, i, j, point, lightName, father.transform, c);
					
					lightPoints [i, j] = pointOfLight;

					yield return new WaitForSeconds(CurrentLevel.timeBetweenEachTileToSpawn);
			}


		for (int x = 0; x < CurrentLevel.x; x++)
			for (int y = 0; y < CurrentLevel.y; y++)
				for (int k = 0; k < CurrentLevel.activeLights.Count; k++)
					if (lightPoints[x, y].x == CurrentLevel.activeLights[k].x && lightPoints[x, y].y == CurrentLevel.activeLights[k].y)
						lightPoints[x, y].Turn();
	}

    #endregion

	BlockType GetBlockType(int x, int y)
	{
		BlockType bT = BlockType.None;

		for (int i = 0; i < currentLevel.activeLights.Count; i++)
		{
			if (currentLevel.activeLights[i].x == x && currentLevel.activeLights[i].y == y)
				bT = BlockType.InteractiveLight;
		}

		return bT;
	}

    #region Actions coming from player input

	public List<Vector2> GetNeighbors (Vector3 point)
	{
		List<Vector2> neighbors = new List<Vector2> ();
		Vector2 lightPoint = GetLightFromPoint (point);

		// Cross neighbors

		if (lightPoint.x - 1 >= 0 && lightPoint.x - 1 < currentLevel.x)
			neighbors.Add (new Vector2 (lightPoint.x - 1, lightPoint.y));

		if (lightPoint.x + 1 >= 0 && lightPoint.x + 1 < currentLevel.x)
			neighbors.Add (new Vector2 (lightPoint.x + 1, lightPoint.y));

		if (lightPoint.y - 1 >= 0 && lightPoint.y - 1 < currentLevel.y)
			neighbors.Add (new Vector2 (lightPoint.x, lightPoint.y - 1));

		if (lightPoint.y + 1 >= 0 && lightPoint.y + 1 < currentLevel.y)
			neighbors.Add (new Vector2 (lightPoint.x, lightPoint.y + 1));

		neighbors.Add (lightPoint); // Starting point

		return neighbors;
	}

	public Vector2 GetLightFromPoint(Vector3 point)
	{
		float x = Mathf.RoundToInt (Utility.Map (point.x, bottomPoint.x, -bottomPoint.x, 0, currentLevel.x));
		float y = Mathf.RoundToInt (Utility.Map (point.y, bottomPoint.y, -bottomPoint.y, 0, currentLevel.y));

		return new Vector2 (x, y);
	}

	public void TurnLight(int x, int y)
	{
		lightPoints[x, y].Turn();
	}

	public bool CheckLevelCompleted()
	{
		int i = 0;

		if (currentLevel == null)
			Debug.Log ("null");

		for (int x = 0; x < currentLevel.x; x++)
			for (int y = 0; y < currentLevel.y; y++)
				if (lightPoints[x, y].blockType == BlockType.InteractiveLight && lightPoints[x, y].isOn)
					i++;

		if (i == 0)
			return true;

		return false;
	}

    #region Get the active lights on the scene

	public void DebugActiveLights() // Button on the screen
	{
		string strActiveLights = "";
		int first = 0;

		for (int x = 0; x < currentLevel.x; x++)
			for (int y = 0; y < currentLevel.y; y++)
				if (lightPoints[x, y].blockType == BlockType.InteractiveLight && lightPoints[x, y].isOn)
					if (first == 0)
					{
						first++;
						strActiveLights += x + "," + y;
					}
					else
						strActiveLights += "," + x + "," + y;

		Debug.Log(strActiveLights);
	}

    #endregion

    #endregion
}