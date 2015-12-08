﻿using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public static Grid Instance;

    [HideInInspector] public Node[,] grid;
    [HideInInspector] public Vector2 mapSize;
    [HideInInspector] public float diameter;
    [HideInInspector] public float radius = .5F;
    [HideInInspector] public int mapSizeX, mapSizeZ;

    public LayerMask occupedLayers;
    public Transform floor; // Quad

    private void Awake()
    {
        Instance = this;

        diameter = radius * 2F;
        mapSize.x = floor.localScale.x;
        mapSize.y = floor.localScale.y;

        mapSizeX = Mathf.RoundToInt(mapSize.x / diameter);
        mapSizeZ = Mathf.RoundToInt(mapSize.y / diameter);

        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid = new Node[mapSizeX, mapSizeZ];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeX; z++)
            {
                bool ocupped = Physics.CheckSphere(GetPointFromNode(x, z), radius, occupedLayers);
                grid[x, z] = new Node(x, z, ocupped);
            }
        }
    }

    public Vector3 GetPointFromNode(int x, int z)
    {
        return new Vector3(-mapSizeX / 2F + x + radius, 0F, -mapSizeZ / 2F + z + radius);
    }

    public Node GetNodeFromPoint(Vector3 point)
    {
        float percentX = (point.x + mapSize.x / 2F) / mapSize.x;
        float percentY = (point.z + mapSize.y / 2F) / mapSize.y;

        int x = Mathf.RoundToInt((mapSizeX - 1F) * percentX);
        int z = Mathf.RoundToInt((mapSizeZ - 1F) * percentY);

        return grid[x, z];
    }

    public List<Node> GetNeighbours(Node node, float boundX, float boundZ)
    {
        List<Node> neighbors = new List<Node>();

        int initialX = Mathf.RoundToInt((node.x - boundX / 2F) + radius);
        int finalX = Mathf.RoundToInt((node.x + boundX / 2F) + radius);
        int initialZ = Mathf.RoundToInt((node.z - boundZ / 2F) + radius);
        int finalZ = Mathf.RoundToInt((node.z + boundZ / 2F) + radius);

        for (int x = initialX; x <= finalX; x++)
        {
            for (int z = initialZ; z <= finalZ; z++)
            {
                if (x >= 0 && x < mapSizeX && z >= 0 && z < mapSizeZ)
                    neighbors.Add(grid[x, z]);
            }
        }
        return neighbors;
    }

    public void SetTileOcuppancy(int x, int z, bool ocuppancy)
    {
        grid[x, z].isOccuped = ocuppancy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(mapSizeX, 1F, mapSizeX));

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                if (grid[x, z].isOccuped) Gizmos.color = Color.yellow;
                else Gizmos.color = Color.gray;

                Gizmos.DrawCube(GetPointFromNode(x, z), Vector3.one * (radius * 2F - .1F));
            }
        }
    }
}