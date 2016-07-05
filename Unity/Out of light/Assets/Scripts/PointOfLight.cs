using UnityEngine;

public enum BlockType {InteractiveLight, None};

public class PointOfLight : MonoBehaviour
{
    public Transform lightSource;
	public BlockType blockType;
	string name;
	Color color;

	Material lightMat;
	Renderer rend;
	Transform parent;
    Component halo;

    [HideInInspector] public bool isOn;
    [HideInInspector] public Vector3 worldPoint;
    [HideInInspector] public int x;
    [HideInInspector] public int y;

	public void Initialize(BlockType _blockType, int _x, int _y, Vector3 point, string _name, Transform _parent, Color c, bool _isOn = false)
	{
		blockType = _blockType;
		x = _x;
		y = _y;
		worldPoint = point;
		name = _name;
		color = c;
		parent = _parent;
		isOn = _isOn;
	}

    private void Start()
    {
		transform.position = worldPoint;
		transform.parent = parent;
		gameObject.name = name;

        rend = GetComponentInChildren<Renderer>();
        halo = lightSource.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, isOn, null);

		lightMat = new Material(rend.sharedMaterial);
		lightMat.color = color;
		rend.sharedMaterial = lightMat;
    }

    public void Turn()
    {
		switch (blockType)
		{
			default:
			{
				isOn = !isOn;
				halo.GetType().GetProperty("enabled").SetValue(halo, isOn, null);
				lightSource.position = (isOn) ? lightSource.position - Vector3.forward * .25F : lightSource.position + Vector3.forward * .25F;
				break;
			}
		}
    }
}