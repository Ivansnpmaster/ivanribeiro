using UnityEngine;

public static class Utility
{
	public static Rect BuildRect(Rect rect)
	{
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		
		rect = new Rect(rect.x * screenWidth, rect.y * screenHeight, rect.width * screenWidth, rect.height * screenHeight);
		return rect;
	}
}