using UnityEngine;

public class BorderControl : MonoBehaviour
{
    [Header("Map properties")]
    public Vector2 mapSize;
    public Vector2 maxMapSize; // Must be bigger than mapSize

    [Header("Transforms")]
    public Transform borderPrefab; // Cube prefab
    public Transform floorMap; // Plane

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        string parentName = "Border holder";

        if (GameObject.Find(parentName))
            DestroyImmediate(GameObject.Find(parentName));

        if (mapSize.x > maxMapSize.x) mapSize.x = maxMapSize.x;
        if (mapSize.y > maxMapSize.y) mapSize.y = maxMapSize.y;

        floorMap.localScale = new Vector3(mapSize.x, 100F, mapSize.y) / 10F;

        GameObject borderParent = new GameObject();
        borderParent.name = parentName;
        borderParent.transform.parent = transform;

        Vector3 position = new Vector3((maxMapSize.x + mapSize.x) / 4F, 0F, 0F);
        Vector3 scale = new Vector3(maxMapSize.x / 2F - mapSize.x / 2F, 1F, mapSize.y);

        // Right border
        SetBorder(borderParent.transform, borderPrefab, position, scale, "Right border");

        // Left border
        SetBorder(borderParent.transform, borderPrefab, -position, scale, "Left border");

        // Upper border
        position = new Vector3(0F, 0F, (maxMapSize.y + mapSize.y) / 4F);
        scale = new Vector3(maxMapSize.x, 1F, maxMapSize.y / 2F - mapSize.y / 2F);
        SetBorder(borderParent.transform, borderPrefab, position, scale, "Upper border");

        // Bottom border
        SetBorder(borderParent.transform, borderPrefab, -position, scale, "Bottom border");
    }

    void SetBorder(Transform parent, Transform prefabBorder, Vector3 position, Vector3 scale, string name)
    {
        Transform border = Instantiate(prefabBorder, position, Quaternion.identity) as Transform;
        border.gameObject.name = name;
        border.parent = parent;
        border.localScale = scale;
    }
}
