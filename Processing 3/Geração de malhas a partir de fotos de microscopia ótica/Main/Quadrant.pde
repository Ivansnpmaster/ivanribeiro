/*
  Created by: Ivan Ribeiro
  Date: 06/2016 - Current
*/

class Quadrant
{
  int startX;
  int startY;
  int endX;
  int endY;
  
  ArrayList<Dot> dots;
  Histogram histogram;
  color c;

  Quadrant(Dot[][] dotsSource, int beginX, int beginY, int _endX, int _endY)
  {
    dots = new ArrayList<Dot>();
    c = color(random(255), random(255), random(255));
    
    startX = beginX;
    startY = beginY;
    endX = _endX;
    endY = _endY;
    
    for (int i = startX; i <= endX; i++)
      for (int j = startY; j <= endY; j++)
      {
        if (dotsSource[i][j].IsVisible())
          dots.add(dotsSource[i][j]);
      }

    histogram = new Histogram(dots);
  }
}