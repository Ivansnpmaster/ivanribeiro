using UnityEngine;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    MapGenerator mapGenerator;

    void Awake()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
    }

    void Update()
    {
        TurnThemAll();
    }

    private void TurnThemAll()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.name.Contains("Box"))
                {
                    List<Vector2> neighbors = mapGenerator.GetNeighbors(hit.point);

                    for (int i = 0; i < neighbors.Count; i++)
                        mapGenerator.TurnLight((int)neighbors[i].x, (int)neighbors[i].y);
                }
            }
        }
    }
}