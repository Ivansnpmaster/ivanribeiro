using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour
{
	public Transform toRotationAndPosition;
	public float timeToReach;

	Quaternion oldQuat;
	Vector3 oldPos;

	bool isAnimating = false;

	void Start()
	{
		oldQuat = transform.rotation;
		oldPos = transform.position;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(Animate());
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (!isAnimating)
			{
				isAnimating = true;
				transform.position = oldPos;
				transform.rotation = oldQuat;
				StartCoroutine(Animate());
			}
		}
	}

	public IEnumerator Animate()
	{
		float currentTime = 0F;

		while(currentTime < timeToReach)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, toRotationAndPosition.rotation, timeToReach * Time.deltaTime);
			transform.position = Vector3.Lerp(transform.position, toRotationAndPosition.position, timeToReach * Time.deltaTime);
			yield return null;
			currentTime += Time.deltaTime;
		}

		isAnimating = false;
	}
}