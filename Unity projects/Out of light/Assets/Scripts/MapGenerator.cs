using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
	public Level currentLevel;

	public int width;
	public int height;
	
	public LightManager lightPrefab;
	public LightManager[,] lights;
	
	Vector3 bottomPoint;
	Color from;
	Color to;
	
	private void Start()
	{
		from = Utility.GetRandomColor();
		to = Utility.GetRandomColor(from);
		
		bottomPoint = new Vector3(-width / 2F, -height / 2F, 0F);

		if (currentLevel != null)
			Generate();
		else
			GenerateLevel(currentLevel);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit, 50F))
			{
				List<LightManager> lightsNeighbors = GetNeighbours(hit.point);
				
				for (int i = 0; i < lightsNeighbors.Count; i ++)
					lightsNeighbors[i].Turn();
			}
		}
	}

	public IEnumerator GenerateLevel(Level lv)
	{
		if (GameObject.Find("Lights Holder"))
			DestroyImmediate(GameObject.Find("Lights Holder"));
		
		GameObject lightsHolder = new GameObject("Lights Holder");
		
		lights = new LightManager[lv.x, lv.y];
		
		HashSet<string> activeLights = new HashSet<string>();
		
		for (int i = 0; i < lv.activeLights.Length; i += 4)
			activeLights.Add(lv.activeLights.Substring(lv.activeLights.IndexOf("-") + 1 + i, 3));
		
		from = Utility.GetRandomColor();
		to = Utility.GetRandomColor(from);

		float timeToSpawn = 2F;
		float currentTime = 0F;

		while(currentTime < timeToSpawn)
		{
			for (int y = 0; y < lv.y; y ++)
			{
				for (int x = 0; x < lv.x; x ++)
				{
					Vector3 point = new Vector3(y + bottomPoint.x, x + bottomPoint.y, 0F);
					
					lights[y, x] = Instantiate (lightPrefab, point, lightPrefab.transform.rotation) as LightManager;
					lights[y, x].gameObject.name = "X: " + y + "\tY:" + x;
					lights[y, x].SetConf(y, x, point);
					lights[y, x].transform.parent = lightsHolder.transform;
					
					Renderer obstacleRenderer = lights[y, x].rend;
					Material obstacleMaterial = new Material(obstacleRenderer.sharedMaterial);
					float colorPercent = ((lights[y, x].y / (float) height) + (lights[y, x].x / (float) width)) * .5F;
					
					obstacleMaterial.color = Color.Lerp(from, to, colorPercent);
					obstacleRenderer.sharedMaterial = obstacleMaterial;
					
					if (activeLights.Contains(string.Format("{0},{1}", y, x)))
						lights[y, x].Turn();
					
					yield return null;
					currentTime += Time.deltaTime;
				}
			}
		}



	}

	public void Generate()
	{
		if (GameObject.Find("Lights Holder"))
			DestroyImmediate(GameObject.Find("Lights Holder"));
		
		GameObject lightsHolder = new GameObject("Lights Holder");
		
		lights = new LightManager[width, height];
		
		for (int x = 0; x < width; x ++)
		{
			for (int y = 0; y < height; y ++)
			{
				Vector3 point = new Vector3(x + bottomPoint.x, y + bottomPoint.y, 0F);

				lights[x, y] = Instantiate (lightPrefab, point, lightPrefab.transform.rotation) as LightManager;
				lights[x, y].gameObject.name = "X: " + x + "\tY:" + y;
				lights[x, y].SetConf(x, y, point);
				lights[x, y].transform.parent = lightsHolder.transform;
				
				Renderer obstacleRenderer = lights[x, y].rend;
				Material obstacleMaterial = new Material(obstacleRenderer.sharedMaterial);
				float colorPercent = ((lights[x, y].y / (float) height) + (lights[x, y].x / (float) width)) * .5F;
				
				obstacleMaterial.color = Color.Lerp(from, to, colorPercent);
				obstacleRenderer.sharedMaterial = obstacleMaterial;
			}
		}
	}
	
	public List<LightManager> GetNeighbours(Vector3 point)
	{
		List<LightManager> neighbours = new List<LightManager>();
		LightManager lm = GetLightFromPoint(point);
		
		for (int x = -1; x <= 1; x ++)
		{
			for (int y = -1; y <= 1; y ++)
			{
				if ((x == -1 && y == -1) || (x == 1 && y == 1) || (x == -1 && y == 1) || (x == 1 && y == -1)) continue; 
				
				int checkX = lm.x + x;
				int checkY = lm.y + y;
				
				if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
					neighbours.Add(lights[checkX, checkY]);
			}
		}
		return neighbours;
	}
	
	public LightManager GetLightFromPoint(Vector3 point)
	{
		float percentX = (point.x + width * .5F) / width;
		float percentY = (point.y + height * .5F) / height;
		
		int x = Mathf.Abs(Mathf.RoundToInt(width * percentX));
		int y = Mathf.Abs(Mathf.RoundToInt(height * percentY));
		
		return lights[x, y];
	}
}