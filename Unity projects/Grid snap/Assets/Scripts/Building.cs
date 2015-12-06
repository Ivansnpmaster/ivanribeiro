using UnityEngine;
using System.Collections.Generic;

public class Building : MonoBehaviour
{
	[HideInInspector] public bool placed;
	[HideInInspector] public int x;
	[HideInInspector] public int z;
	public BoxCollider boxCollider;

	List<Node> neighbors = new List<Node>();

	public Node currentNode;
	float colliderBoundX;
	float colliderBoundZ;

	int initialX;
	int finalX;
	int initialZ;
	int finalZ;

	void Awake()
	{
		Player.Instance.PCurrentBuilding = this;
		//currentNode = node;

		boxCollider = GetComponentInChildren<BoxCollider>();
		colliderBoundX = boxCollider.size.x;
		colliderBoundZ = boxCollider.size.z;
	}

	public void SetPosition(Vector3 point)
	{
		if (!placed)
			placed = TryToPlace(point);

		if (placed)
		{
			Player.Instance.currentAction = Action.None;
			Player.Instance.PCurrentBuilding = null;
		}
	}


	private bool TryToPlace(Vector3 point)
	{
		Node actualNode = Grid.Instance.GetNodeFromPoint(transform.position);
		List<Node> neighbors = Grid.Instance.GetNeighbours(actualNode, colliderBoundX, colliderBoundZ);
		bool canPlace = true;

		for (int i = 0; i < neighbors.Count; i ++)
		{
			if (neighbors[i].isOccuped)
				canPlace = false;
		}

		if (canPlace)
		{
			Node node = Grid.Instance.GetNodeFromPoint(point);
			Vector3 position = Grid.Instance.GetPointFromNode(node.x, node.z);

			transform.position = position;
			return true;
		}

		return false;
	}

	public void MoveBuilding(Vector3 point)
	{
		Node node = Grid.Instance.GetNodeFromPoint(point);
		Vector3 position = Grid.Instance.GetPointFromNode(node.x, node.z);

		transform.position = position;

		// Need to check if is possible to put the building
		if (currentNode.x != node.x && currentNode.z != node.z)
		{
			currentNode = node;

			for (int i = 0; i < neighbors.Count; i ++)
            {
				for (int x = 0; x < Grid.Instance.mapSizeX; x ++)
				{
					for (int z = 0; z < Grid.Instance.mapSizeX; z ++)
					{
						if (neighbors[i].x == Grid.Instance.grid[x, z].x && neighbors[i].z == Grid.Instance.grid[x, z].z)
							Grid.Instance.grid[x, z].isOccuped = false;
					}
				}
			}

			neighbors.Clear();

			neighbors = Grid.Instance.GetNeighbours(currentNode, colliderBoundX, colliderBoundZ);

			for (int x = 0; x < Grid.Instance.mapSizeX; x ++)
			{
				for (int z = 0; z < Grid.Instance.mapSizeX; z ++)
				{
					if (neighbors.Contains(Grid.Instance.grid[x, z]))
						Grid.Instance.grid[x, z].isOccuped = true;
                }
			}
		}
	}
}