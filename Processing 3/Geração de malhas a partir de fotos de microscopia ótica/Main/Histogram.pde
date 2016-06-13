/*
  Created by: Ivan Ribeiro
  Date: 05/2016 - Current
*/

class Histogram
{
  int[] hist;

  Histogram(ArrayList<Dot> visibleDots)
  {
    hist = new int[256];

    for (int i = 0; i < visibleDots.size(); i++)
    {
      int pHeight = round(visibleDots.get(i).Z());
      hist[pHeight]++;
    }
  }

  void ShowHistogram()
  {
    for (int i = 0; i < 256; i+= 2)
      println("(" + i + ": " + hist[i] + ") - (" + (i + 1) + ": " + hist[i + 1] + ")");
  }
}