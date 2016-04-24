using UnityEngine;

public class PointOfLight : MonoBehaviour
{
    public Transform lightSource;
    Component halo;

    [HideInInspector]
    public Renderer rend;
    [HideInInspector]
    public bool isOn = false;
    [HideInInspector]
    public Vector3 worldPoint;
    [HideInInspector]
    public int x;
    [HideInInspector]
    public int y;

    private void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        halo = lightSource.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, isOn, null);
    }

    public void Turn()
    {
        isOn = !isOn;
        halo.GetType().GetProperty("enabled").SetValue(halo, isOn, null);
        lightSource.position = (isOn) ? lightSource.position - Vector3.forward * .25F : lightSource.position + Vector3.forward * .25F;
    }

    public void SetConf(int _x, int _y, Vector3 point)
    {
        x = _x;
        y = _y;
        worldPoint = point;
    }
}