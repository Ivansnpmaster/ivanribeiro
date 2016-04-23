using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
	BuildingController bController;

	private void Awake()
	{
		bController = FindObjectOfType<BuildingController>();
	}

	private void Update()
	{
        if (EventSystem.current.IsPointerOverGameObject()) // If mouse is over something in the UI
            return;
	}

	// Will be in screen buttons
	public void Set_BuildingMode(BuildingState bState, int buildingIndex)
	{
		bController.ChangeState(bState, buildingIndex);
	}

	public void Set_BuildingMode(BuildingState bState)
	{
		bController.ChangeState(bState);
	}

	public void Set_BuildingMode(int index)
	{
		bController.ChangeState(index);
	}
}