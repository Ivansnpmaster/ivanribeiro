using UnityEngine;
using System.Collections;

public class BuildController : MonoBehaviour
{
    public Transform buildingsHolder;
    public Building[] buildings;

    public void SpawnBuild(int index)
    {
        index = Mathf.Clamp(index, 0, buildings.Length);

        Building b = Instantiate(buildings[index], Vector3.zero, buildings[index].transform.rotation) as Building;
        b.currentNode = Grid.Instance.GetNodeFromPoint(Vector3.zero);
        b.transform.parent = buildingsHolder;
        Player.Instance.PCurrentBuilding = b;
    }
}