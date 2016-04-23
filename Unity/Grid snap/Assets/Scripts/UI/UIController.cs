using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
	public GameObject buildingsHolder;
	public GameObject topics;

	MouseController mController;

	private void Awake()
	{
		mController = FindObjectOfType<MouseController>();
	}

	public void ShowBuildings()
	{
		buildingsHolder.SetActive(true);
		topics.SetActive(false);
	}

	public void HideBuildings()
	{
		topics.SetActive(true);
		buildingsHolder.SetActive(false);
	}

	public void SetCurrentBuilding(BuildingState state, int index)
	{
		mController.Set_BuildingMode(state, index);
	}

	public void SetCurrentBuilding(BuildingState state)
	{
		mController.Set_BuildingMode(state);
	}

	public void SetCurrentBuilding(int index)
	{
		mController.Set_BuildingMode(index);
	}
}