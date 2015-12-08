using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public Grid grid;
    public float distanceToZero;

    void Awake()
    {
        GameObject angleReference = new GameObject("Angle reference");
        angleReference.transform.rotation = Quaternion.Euler(-45F, 225F, -45F);

        transform.rotation = Quaternion.Euler(45F, 45F, 0);
        transform.position = angleReference.transform.forward * distanceToZero;

        Destroy(angleReference);
    }
}