using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
	public static Grid Instance;

	[HideInInspector] public Vector2 mapSize;

	public LayerMask occupedLayers;
	public Transform floor; // Quad
	public float diameter;
	public float radius = .5F;

	[HideInInspector] public Node[,] grid;

	public int mapSizeX, mapSizeY;

	private void Awake ()
	{
		Instance = this;

		diameter = radius * 2F;
		mapSize.x = floor.localScale.x;
		mapSize.y = floor.localScale.y;

		mapSizeX = Mathf.RoundToInt(mapSize.x / diameter);
		mapSizeY = Mathf.RoundToInt(mapSize.y / diameter);

		GenerateGrid();
	}

	public void GenerateGrid()
	{
		grid = new Node[mapSizeX, mapSizeY];

		for (int x = 0; x < mapSizeX; x ++)
		{
			for (int z = 0; z < mapSizeX; z ++)
			{
				bool ocupped = Physics.CheckSphere(GetPointFromNode(x, z), radius, occupedLayers);
				grid[x, z] = new Node(x, z, ocupped);
			}
		}
	}

	public Vector3 GetPointFromNode(int x, int z)
	{
		return new Vector3(-mapSizeX / 2F + x + radius, 0F, -mapSizeY / 2F + z + radius);
	}

	public Node GetNodeFromPoint(Vector3 point)
	{
		float percentX = (point.x + mapSize.x / 2F) / mapSize.x;
		float percentY = (point.z + mapSize.y / 2F) / mapSize.y;
		
		int x = Mathf.RoundToInt((mapSizeX - 1) * percentX);
		int z = Mathf.RoundToInt((mapSizeY - 1) * percentY);
		
		return grid[x, z];
	}

	public List<Node> GetNeighbours(Node node, float boundX, float boundZ)
	{
		List<Node> neighbors = new List<Node>();

		int initialX = Mathf.RoundToInt((node.x - boundX / 2));
		int finalX = Mathf.RoundToInt((node.x + boundX / 2));
		int initialZ = Mathf.RoundToInt((node.z - boundZ / 2));
		int finalZ = Mathf.RoundToInt((node.z + boundZ / 2));
		
		for (int x = initialX; x <= finalX; x ++)
		{
			for (int y = initialZ; y <= finalZ; y ++)
			{
				int checkX = node.x + x;
				int checkY = node.z + y;
				
				if (checkX >= 0 && checkX < mapSizeX && checkY >= 0 && checkY < mapSizeY)
					neighbors.Add(grid[checkX, checkY]);
			}
		}
		return neighbors;
	}

	public void SetOcuppancy(List<Node> nodes)
	{
		for (int i = 0; i < nodes.Count; i ++)
		{
			for (int x = 0; x < mapSizeX; x ++)
			{
				for (int z = 0; z < mapSizeX; z ++)
				{
					if (nodes[i].x == grid[x, z].x && nodes[i].z == grid[x, z].z)
						grid[x, z].isOccuped = false;
                		}
            		}
        	}
    	}
    
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(mapSizeX, 1F, mapSizeX));

		for (int x = 0; x < mapSizeX; x ++)
		{
			for (int z = 0; z < mapSizeY; z ++)
            		{
				if (grid[x, z].isOccuped) Gizmos.color = Color.yellow;
				else Gizmos.color = Color.gray;

				Gizmos.DrawCube(GetPointFromNode(x, z), Vector3.one * (radius * 2F - .1F));
            		}
        	}
	}
}
