using UnityEngine;

public enum Action { None, MovingBuild, BuildSelected }

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
            if (value == null && Player.Instance.currentAction == Action.None)
                Destroy(currentBuilding.gameObject);

            currentBuilding = value;

            if (currentBuilding != null) Player.Instance.currentAction = Action.MovingBuild;
            else Player.Instance.currentAction = Action.None;
        }
    }

    #endregion

    public void SetPosition(RaycastHit hit)
    {
        currentBuilding.SetPosition(hit.point);
    }

    public void BuildSelected(Node mouseNode, RaycastHit hit)
    {
        if (mouseNode.x != currentBuilding.currentNode.x && mouseNode.z != currentBuilding.currentNode.z)
            currentBuilding.MoveBuilding(hit.point);
    }
}