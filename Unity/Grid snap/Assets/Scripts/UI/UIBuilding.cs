using UnityEngine;
using UnityEngine.UI;

public class UIBuilding : MonoBehaviour
{
	public GameObject canvasGO;
	public RectTransform uiButtons;

	MouseController mController;
	Building myBuilding;

	private void Awake()
	{
		mController = FindObjectOfType<MouseController>();
		myBuilding = FindObjectOfType<BuildingController>().currentBuilding;

		canvasGO = GameObject.Find("Canvas");

		uiButtons.transform.SetParent(canvasGO.transform, false);

		UpdatePanelBuildingsButtons();
	}

	public void UpdatePanelBuildingsButtons()
	{
		//Vector2 pos2D = Camera.main.WorldToScreenPoint(myBuilding.buildingPivot.position);
		//uiButtons.anchoredPosition = new Vector2(Screen.width / 2 - pos2D.x, Screen.height / 2 - pos2D.y);
	}

	// Disable the screen 
	public void DisableUI()
	{
		Destroy(gameObject);
	}

	// Will be at cancel button on the screen
	public void CancelBuilding()
	{
		mController.Set_BuildingMode(BuildingState.NONE);
	} 
}