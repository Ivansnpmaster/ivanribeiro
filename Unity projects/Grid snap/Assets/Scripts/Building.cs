using UnityEngine;
using System.Collections.Generic;

public class Building : MonoBehaviour
{
    [HideInInspector]
    public bool placed;
    [HideInInspector]
    public BoxCollider boxCollider;
    [HideInInspector]
    public Node currentNode;

    public Transform graphics;

    float colliderBoundX;
    float colliderBoundZ;

    private void Awake()
    {
        boxCollider = GetComponentInChildren<BoxCollider>();
        colliderBoundX = graphics.localScale.x;
        colliderBoundZ = graphics.localScale.z;
    }

    private void OnEnable()
    {
        Player.Instance.PCurrentBuilding = this;
    }

    public void SetPosition(Vector3 point)
    {
        if (!placed)
            placed = TryToPlace(point);

        if (placed)
            Player.Instance.PCurrentBuilding = null;
    }

    private bool TryToPlace(Vector3 point)
    {
        print("Try to place!");

        Node actualNode = Grid.Instance.GetNodeFromPoint(point);
        List<Node> neighbors = Grid.Instance.GetNeighbours(actualNode, colliderBoundX, colliderBoundZ);

        bool canPlace = true;

        for (int i = 0; i < neighbors.Count; i++)
        {
            if (neighbors[i].isOccuped)
                canPlace = false;
        }

        if (canPlace)
        {
            print("Placed!");

            for (int i = 0; i < neighbors.Count; i++)
            {
                Grid.Instance.SetTileOcuppancy(neighbors[i].x, neighbors[i].z, true);
            }

            currentNode = actualNode;
            transform.position = Grid.Instance.GetPointFromNode(actualNode.x, actualNode.z);
            return true;
        }

        return false;
    }

    public void MoveBuilding(Vector3 point)
    {
        Node node = Grid.Instance.GetNodeFromPoint(point);
        Vector3 position = Grid.Instance.GetPointFromNode(node.x, node.z);

        transform.position = position;
    }
}