using UnityEngine;

[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour
{
	public static Player Instance;

	[HideInInspector] public Action currentAction;

	PlayerController playerController;

	private void Awake ()
	{
		Instance = this;
		playerController = GetComponent<PlayerController>();
	}

	public Building PCurrentBuilding
	{
		get { return playerController.CurrentBuilding; }
		set { playerController.CurrentBuilding = value; }
	}

	private void Update ()
	{
		if (PCurrentBuilding != null)
		{
			if (currentAction == Action.MovingBuild)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					PCurrentBuilding = null;
					return;
				}

				if (Input.GetMouseButtonDown(0))
				{
					playerController.SetPosition();
					return;
				}

				playerController.BuildSelected();
			}
		}
	}
}