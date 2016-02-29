using UnityEngine;
using System.Collections.Generic;

public static class Utility
{
	public static List<Color> colors = new List<Color>() {
		Color.black,
		Color.white,
		Color.grey,
		Color.green,
		Color.red,
		Color.blue,
		Color.cyan,
		Color.gray,
		Color.magenta,
		Color.yellow
	};

	public static Color GetRandomColor()
	{
		return colors[Random.Range(0, colors.Count)];
	}

	public static Color GetRandomColor(Color index)
	{
		Color newColor = colors[Random.Range(0, colors.Count)];

		while (newColor == index)
			newColor = colors[Random.Range(0, colors.Count)];

		return newColor;
	}
}