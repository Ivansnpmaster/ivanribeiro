/*
  Created by: Ivan Ribeiro
  Date: 05/2016 - Current
*/

class Dot
{
  PVector pos;
  float zColor;
  boolean visible = false;
  boolean visited = false;
  int index;

  Dot(int _x, int _y, int arrayWidth)
  {
    pos = new PVector(_x, _y);
    index = _x + _y * arrayWidth;
  }

  void Z(float depth)
  {
    pos.z = depth;
    zColor = map(pos.z, 0, 100, 0, 255);
  }
  
  float Z()
  {
    return zColor;
  }

  boolean Show(float min, float max)
  {
    if (pos.z >= min && pos.z <= max)
    {
      //color c = color(zColor, 0, zColor);
      color c = color(0);
      stroke(c);
      point(pos.x, pos.y);//, pos.z);
      visible = true;
      return true;
    }
    return false;
  }

  ArrayList<Dot> GetNeighbors(ArrayList<Dot> dots, Grid grid)
  {
    ArrayList<Dot> n = new ArrayList<Dot>();

    for (int x = -1; x < 2; x++)
    {
      for (int y = -1; y < 2; y++)
      {
        if (x == 0 && y == 0) continue;

        int indexX = (int) (pos.x + x);
        int indexY = (int) (pos.y + y);

        if (indexX > -1 && indexX < grid.w && indexY > -1 && indexY < grid.h)
        {
          if (dots.contains(grid.dots[indexX][indexY]) && !grid.dots[indexX][indexY].visited)
          {
            n.add(grid.dots[indexX][indexY]);
            return n;
          }
        }
      }
    }
    return n;
  }
}