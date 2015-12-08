using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public static Player Instance;

    [HideInInspector]
    public Action currentAction;

    PlayerController playerController;

    private void Awake()
    {
        Instance = this;
        playerController = GetComponent<PlayerController>();

        mouseNode = new Node();
    }

    public Building PCurrentBuilding
    {
        get { return playerController.CurrentBuilding; }
        set
        {
            playerController.CurrentBuilding = value;
        }
    }

    Node mouseNode;
    Node currentMouseNode;

    RaycastHit hit;
    Ray ray;

    private void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        currentMouseNode = new Node();

        if (Physics.Raycast(ray, out hit, float.MaxValue, playerController.floorLayer))
        {
            currentMouseNode = Grid.Instance.GetNodeFromPoint(hit.point);

            if (currentMouseNode.x != mouseNode.x || currentMouseNode.z != mouseNode.z)
            {
                mouseNode = currentMouseNode;

                if (currentAction == Action.MovingBuild)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        currentAction = Action.None;
                        PCurrentBuilding = null;
                        return;
                    }

                    playerController.BuildSelected(currentMouseNode, hit);
                }
            }

            // If clicks to set the building
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAction == Action.MovingBuild)
                {
                    playerController.SetPosition(hit);
                    return;
                }
            }
        }
    }
}