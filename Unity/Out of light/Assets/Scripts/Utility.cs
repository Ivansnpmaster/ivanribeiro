using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Utility
{
    public static List<Color> colors = new List<Color>()
    {
        Color.black,
        Color.white,
        Color.green,
        Color.red,
        Color.blue,
        Color.cyan,
        Color.gray,
        Color.magenta,
        Color.yellow
    };

    public static float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

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

    public static List<Vector2> GetLightsFromSource(string activeLights)
    {
		List<Vector2> activeIndexes = new List<Vector2>();

		if (activeLights.Length != 0)
		{
	        string[] str = activeLights.Split(',').Select(sValue => sValue.Trim()).ToArray();

    	    for (int i = 0; i < str.Length; i += 2)
        	    activeIndexes.Add(new Vector2(int.Parse(str[i]), int.Parse(str[i + 1])));
		}

        return activeIndexes;
    }
}