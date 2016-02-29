using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour
{
	public Transform lightSource;
	Component halo;

	[HideInInspector] public Renderer rend;
	[HideInInspector] public bool isOn = false;
	[HideInInspector] public int x;
	[HideInInspector] public int y;

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
		lightSource.position = (isOn)? lightSource.position - Vector3.forward / 4F : lightSource.position + Vector3.forward / 4F;
	}

	public void SetXY(int _x, int _y)
	{
		x = _x;
		y = _y;
	}
}