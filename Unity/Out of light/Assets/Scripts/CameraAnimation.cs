using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour
{
    public Transform toRotationAndPosition;
    public float timeToReach;

    Quaternion oldQuat;
    Vector3 oldPos;

    private void Awake()
    {
        oldQuat = transform.rotation;
        oldPos = transform.position;
    }

    public IEnumerator Animate()
    {
        transform.position = oldPos;
        transform.rotation = oldQuat;

        float currentTime = 0F;

        while (currentTime < timeToReach)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotationAndPosition.rotation, timeToReach * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, toRotationAndPosition.position, timeToReach * Time.deltaTime);
            yield return null;
            currentTime += Time.deltaTime;
        }

        transform.position = toRotationAndPosition.position;
        transform.rotation = toRotationAndPosition.rotation;
    }
}