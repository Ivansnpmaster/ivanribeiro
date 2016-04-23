using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public static Grid Instance;

    public Node[,] nodes;
    public Vector2 mapSize;
    public LayerMask occupedLayers;

    float radius = .5F;

    private void Awake()
    {
        Instance = this;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
		int _x = Mathf.RoundToInt(mapSize.x);
		int _z = Mathf.RoundToInt(mapSize.y);

		nodes = new Node[_x, _z];

        for (int x = 0; x < _x; x++)
        {
            for (int z = 0; z < _z; z++)
            {
                bool ocupped = Physics.CheckSphere(GetPointFromNode(x, z), radius, occupedLayers);
                nodes[x, z] = new Node(x, z, ocupped);
            }
        }
    }

    public Vector3 GetPointFromNode(int x, int z)
    {
		return new Vector3(-mapSize.x / 2F + x + radius, 0F, -mapSize.y / 2F + z + radius);
    }

    public Node GetNodeFromPoint(Vector3 point)
    {
        float percentX = (point.x + mapSize.x / 2F) / mapSize.x;
        float percentY = (point.z + mapSize.y / 2F) / mapSize.y;

		int x = Mathf.RoundToInt((mapSize.x - 1F) * percentX);
		int z = Mathf.RoundToInt((mapSize.y - 1F) * percentY);

        return nodes[x, z];
    }

    public List<Node> GetNeighbors(Node node, int boundX, int boundZ)
    {
        List<Node> neighbors = new List<Node>();

		int initialX = node.x - boundX;
		int finalX = node.x + boundX;
        int initialZ = node.z - boundZ;
		int finalZ = node.z + boundZ;

		for (int x = initialX; x <= finalX; x++)
        {
            for (int z = initialZ; z <= finalZ; z++)
            {
				if (x == node.x && z == node.z)
					continue;

				if (x < mapSize.x && z < mapSize.y && x >= 0 && z >= 0)
					neighbors.Add(nodes[x, z]);
            }
        }
        return neighbors;
    }

    public void SetTileOcuppancy(int x, int z, bool ocuppancy)
    {
        nodes[x, z].isOccuped = ocuppancy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(mapSize.x, 1F, mapSize.y));

		for (int x = 0; x < mapSize.x; x++)
        {
			for (int z = 0; z < mapSize.y; z++)
            {
				if (nodes != null)
				{
	                if (nodes[x, z].isOccuped) Gizmos.color = Color.yellow;
	                else Gizmos.color = Color.gray;

	                Gizmos.DrawCube(GetPointFromNode(x, z), Vector3.one * (radius * 2 - .1F));
				}
            }
        }
    }
}