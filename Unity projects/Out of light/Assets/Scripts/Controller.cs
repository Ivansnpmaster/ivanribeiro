using UnityEngine;
using System.Collections.Generic;

public class Controller : MonoBehaviour
{
	public int width;
	public int height;

	public LightManager lightPrefab;

	Vector3 bottomPoint;

	public LightManager[,] lights;

	Color from;
	Color to;

	private void Start()
	{
		from = Utility.GetRandomColor();
		to = Utility.GetRandomColor(from);

		bottomPoint = new Vector3(-width / 2F, -height / 2F, 0F);
		Generate();
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
				lights[x, y] = Instantiate (lightPrefab, new Vector3(x + bottomPoint.x, y + bottomPoint.y, 0F), lightPrefab.transform.rotation) as LightManager;
				lights[x, y].gameObject.name = "X: " + x + "\tY:" + y;
				lights[x, y].SetXY(x, y);
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
		float percentX = (point.x + width / 2F) / width;
		float percentY = (point.y + height / 2F) / height;
		
		int x = Mathf.RoundToInt(width * percentX);
		int y = Mathf.RoundToInt(height * percentY);
		
        return lights[x, y];
    }
    

}