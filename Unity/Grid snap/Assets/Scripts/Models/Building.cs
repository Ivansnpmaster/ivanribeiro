using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
	public Transform buildingPivot;
	public UIBuilding uiBuilding;

	Node centerNode;

	public Node CenterNode
	{
		get { return centerNode; }
		set
		{
			centerNode = value;
			buildingPivot.position = Grid.Instance.GetPointFromNode(centerNode.x, centerNode.z);
		}
	}

	[HideInInspector] public int xWidth;
	[HideInInspector] public int zDepth;
	
	void Awake()
	{
		Bounds boxBounds = GetComponentInChildren<BoxCollider>().bounds;

		xWidth = Mathf.RoundToInt(boxBounds.max.x / 2);
		zDepth = Mathf.RoundToInt(boxBounds.max.z / 2);

		CenterNode = Grid.Instance.GetNodeFromPoint(buildingPivot.position);
		buildingPivot.position = Grid.Instance.GetPointFromNode(centerNode.x, centerNode.z);

		UIBuilding uiBuil = Instantiate(uiBuilding, uiBuilding.transform.position, Quaternion.identity) as UIBuilding;
		uiBuil.transform.SetParent(GameObject.Find("Menu").transform, true);
		uiBuilding = uiBuil;
	}
}