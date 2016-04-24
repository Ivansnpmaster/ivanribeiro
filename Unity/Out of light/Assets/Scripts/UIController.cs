using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
	public Text levelName;
	float timeToFadeLevelName = 3F;

	#region Change the level name and opacity

	private IEnumerator ChangeName(string name)
	{
		levelName.CrossFadeAlpha(1, 0, false);

		float timeToSpawnOneLetter = .5F;
		levelName.text = "";
		
		for(int i = 0; i < name.Length; i ++)
		{
			if(name.Substring(i, 1) == " ")
			{
				levelName.text += " ";
				continue;
			}
			
			float currentTime = 0F;
			
			while(currentTime < timeToSpawnOneLetter)
			{
				yield return null;
				currentTime += Time.deltaTime;
			}
			
			levelName.text += name.Substring(i, 1);
		}
		
		levelName.CrossFadeAlpha(0, timeToFadeLevelName, false); // Target, speed, should ignode Time.timeScale ?
	}
	
	public void ChangeLevelName(string name)
	{
		StartCoroutine("ChangeName", name);
	}

	#endregion
}