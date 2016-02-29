using UnityEngine;
using System.Collections.Generic;

public class LevelEditor : MonoBehaviour
{
	const string tab = "\t";
	const string newLine = "\n";

	public string levelNumber;
	string runTimeLevels;

	Controller controller;

	void Start()
	{
		controller = FindObjectOfType<Controller>();
	}

	public void SetLevelName(string name)
	{
		levelNumber = name;
	}

	public void ClearLevel()
	{
		int xTo = controller.lights.GetLength(0);
		int yTo = controller.lights.GetLength(1);

		for (int x = 0; x < xTo; x ++)
		{
			for (int y = 0; y < yTo; y ++)
			{
				if (controller.lights[x, y].isOn)
					controller.lights[x, y].Turn();
			}
		}
	}

	public void SaveLevel()
	{
		List<string> pairEnabled = new List<string>();

		int xTo = controller.lights.GetLength(0);
		int yTo = controller.lights.GetLength(1);

		for (int x = 0; x < xTo; x ++)
		{
			for (int y = 0; y < yTo; y ++)
			{
				if (controller.lights[x, y].isOn)
					pairEnabled.Add("<light>" + x + "," + y + "</light>");
			}
		}

		runTimeLevels += newLine +
			"<levels>" + newLine +
				tab +"<level>" + newLine + tab + tab +
					"<levelname>" + levelNumber + "</levelname>" + newLine + tab + tab +
					"<levelSizeX>" + controller.width + "</levelSizeX>" + newLine + tab + tab +
					"<levelSizeY>" + controller.height + "</levelSizeY>" + newLine + tab + tab +
					"<lightsout>" + newLine + tab + tab + tab;

		for (int i = 0; i < pairEnabled.Count; i ++)
		{
			runTimeLevels += pairEnabled[i] + newLine + tab + tab;

			if (i != pairEnabled.Count - 1)
				runTimeLevels += tab;
		}

		runTimeLevels += 
					"</lightsout>" + newLine + tab +
				"</level>" + newLine +
			"</levels>";

		System.IO.File.WriteAllText("C:/Users/Ivansnpmaster/Desktop/ivanribeiro/Unity projects/Out of light/Assets/Resources/IO Files/LevelEditor.txt", runTimeLevels);
	}
}