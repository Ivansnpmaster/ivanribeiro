using UnityEngine;

public enum Action { None, MovingBuild, BuildSelected  }

public class PlayerController : MonoBehaviour
{
	public LayerMask floorLayer;

	#region Current building
	
	Building currentBuilding;

	public Building CurrentBuilding
	{
		get { return currentBuilding; }
		set 
		{ 
			currentBuilding = value; 

			if (currentBuilding != null) Player.Instance.currentAction = Action.MovingBuild; 
			else Player.Instance.currentAction = Action.None; 
		}
	}
	
	#endregion

	public void SetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, float.MaxValue, floorLayer))
			currentBuilding.SetPosition(hit.point);
	}
	
	public void BuildSelected()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, float.MaxValue, floorLayer))
			currentBuilding.MoveBuilding(hit.point);
	}
}