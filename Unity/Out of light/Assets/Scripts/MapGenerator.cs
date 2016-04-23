using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
	CameraAnimation camAnim;

	public Level CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }

	public PointOfLight lightPrefab;
	Level currentLevel;
	PointOfLight[,] lightPoints;
	Vector3 bottomPoint = Vector2.zero;
	Color from;
	Color to;

	private void Awake ()
	{
		camAnim = Camera.main.GetComponent<CameraAnimation> ();
	}

	#region In game generating map
	
	public IEnumerator GenerateLevel (Level level)
	{
		camAnim.StartCoroutine("Animate");

		currentLevel = level;
		
		if (GameObject.Find ("Lights holder"))
			GameObject.Destroy (GameObject.Find ("Lights holder"));
		
		GameObject father = new GameObject ("Lights holder");
		
		lightPoints = new PointOfLight[level.x, level.y];
		
		from = Utility.GetRandomColor ();
		to = Utility.GetRandomColor (from);
		
		bottomPoint = new Vector3 (-level.x / 2F, -level.y / 2F, 0F);
		Vector2 maxMatrix = new Vector2 (level.x, level.y);
		
		float currentTime = 0F;
		
		while (currentTime < currentLevel.timeToSpawn)
		{
			for (int x = 0; x < level.x; x++)
			{
				for (int y = 0; y < level.y; y++)
				{
					Vector3 point = new Vector3 (x + .5F + bottomPoint.x, y + bottomPoint.y, 0F); // .5F for alignment purpose
					
					lightPoints [x, y] = NewLight (x, y, point, "X: " + x + " Y:" + y, father.transform, maxMatrix);
					
					yield return null;
					currentTime += Time.deltaTime;
				}
			}
		}

		List<Vector2> activePointsOfLight = Utility.GetLightsFromSource(level.activeLights);

		for (int i = 0; i < activePointsOfLight.Count; i++)
		{
			for (int x = 0; x < level.x; x++)
			{
				for (int y = 0; y < level.y; y++)
				{
					if (lightPoints[x, y].x == activePointsOfLight[i].x && lightPoints[x, y].y == activePointsOfLight[i].y)
						lightPoints [x, y].Turn ();
				}
			}
		}
	}

	#endregion

	#region Initializating lights
	
	private PointOfLight NewLight (int x, int y, Vector3 point, string name, Transform parent, Vector2 maxMatrix)
	{
		PointOfLight pL = Instantiate (lightPrefab, point, lightPrefab.transform.rotation) as PointOfLight;
		pL.gameObject.name = name;
		pL.SetConf (x, y, point);
		pL.transform.parent = parent;
        
		Material lightMat = new Material (pL.rend.sharedMaterial);
		float colorPercent = ((pL.x / maxMatrix.x) + (pL.y / maxMatrix.y)) * .5F;
        
		lightMat.color = Color.Lerp (from, to, colorPercent);
		pL.rend.sharedMaterial = lightMat;
        
		return pL;
	}

	#endregion

	#region Actions coming from player input
	
	public List<Vector2> GetNeighbors (Vector3 point)
	{
		List<Vector2> neighbors = new List<Vector2> ();
		Vector2 lightPoint = GetLightFromPoint (point);

		if (lightPoint.x - 1 >= bottomPoint.x)
			neighbors.Add (new Vector2 (lightPoint.x - 1, lightPoint.y));

		if (lightPoint.x + 1 <= -bottomPoint.x)
			neighbors.Add (new Vector2 (lightPoint.x + 1, lightPoint.y));

		if (lightPoint.y - 1 >= bottomPoint.y)
			neighbors.Add (new Vector2 (lightPoint.x, lightPoint.y - 1));

		if (lightPoint.y + 1 <= -bottomPoint.y)
			neighbors.Add (new Vector2 (lightPoint.x, lightPoint.y + 1));
			
		return neighbors;
	}
	
	public Vector2 GetLightFromPoint (Vector3 point)
	{
		float percentX = (point.x + currentLevel.x * .5F) / currentLevel.x;
		float percentY = (point.y + currentLevel.y * .5F) / currentLevel.y;
		
		int x = Mathf.Abs (Mathf.RoundToInt (currentLevel.x * percentX));
		int y = Mathf.Abs (Mathf.RoundToInt (currentLevel.y * percentY));
		
		return new Vector2 (x, y);
	}

	#endregion
}