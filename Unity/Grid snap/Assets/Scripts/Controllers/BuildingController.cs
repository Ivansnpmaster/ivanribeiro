using UnityEngine;
using UnityEngine.EventSystems;

public enum BuildingState { SELECTED, MOVING, PLACE, NONE };

public class BuildingController : MonoBehaviour
{
	public Building[] buildings;

	BuildingState bState;

	BuildingState BState
	{
		get { return bState; }
		set
		{
			bState = value;
			
			if (bState == BuildingState.NONE)
				currentBuilding.uiBuilding.DisableUI();
		}
	}

	[HideInInspector]
	public Building currentBuilding;

	private void Awake()
	{
		bState = BuildingState.NONE;
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject()) // If mouse is over something in the UI
			return;

		if (BState == BuildingState.SELECTED)
		{
			BState = BuildingState.MOVING;
			currentBuilding.uiBuilding.UpdatePanelBuildingsButtons();
			return;
		}
		else if (BState == BuildingState.MOVING)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				pos.y = 0F;
				Node nodePoint = Grid.Instance.GetNodeFromPoint(pos);

				currentBuilding.CenterNode = nodePoint;

				// Update the UI elements
				currentBuilding.uiBuilding.UpdatePanelBuildingsButtons();
			}
		}
		else if (BState == BuildingState.PLACE)
		{
			BState = BuildingState.NONE;

			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Node nodePoint = Grid.Instance.GetNodeFromPoint(pos);

			currentBuilding.CenterNode = nodePoint;
			currentBuilding = null;
		}
	}

	public void ChangeState(int index)
	{
		if (index >= 0 && index < buildings.Length)
		{
			currentBuilding = Instantiate(buildings[index], Vector3.zero, Quaternion.identity) as Building;
			currentBuilding.gameObject.name = "Building " + index + " " + Random.value;
			BState = BuildingState.SELECTED;
		}
	}

	public void ChangeState(BuildingState newState)
	{
		if (BState != newState)
			BState = newState;
	}

	public void ChangeState(BuildingState newState, int buildingIndex)
	{
		if (BState != newState)
		{
			BState = newState;
			currentBuilding = buildings[buildingIndex];
		}
    }
}