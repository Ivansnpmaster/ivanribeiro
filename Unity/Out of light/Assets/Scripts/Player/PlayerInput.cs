using UnityEngine;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
	public bool devMode;

    private void Update()
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
					List<Vector2> neighbors = LevelController.instance.mapGenerator.GetNeighbors(hit.point);

                    for (int i = 0; i < neighbors.Count; i++)
						LevelController.instance.mapGenerator.TurnLight((int)neighbors[i].x, (int)neighbors[i].y);

					if(!devMode)
						LevelController.instance.CheckLevelCompleted();
                }
            }
        }

		if(Application.isEditor)
		{
			DeleteAllLevelsCompleted();
			GenerateLevel();
		}
    }

	private void DeleteAllLevelsCompleted()
	{
		if (Input.GetKeyDown(KeyCode.Return))
			Utility.DeleteAllLevelKeys();
	}
	private void GenerateLevel()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			LevelController.instance.GenerateNextLevel();
	}
}