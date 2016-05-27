class Dot
{
  PVector pos;
  float zColor;

  Dot(int _x, int _y)
  {
    pos = new PVector(_x, _y);
  }

  void Z(float depth)
  {
    pos.z = depth;
    zColor = map(pos.z, 0, 100, 0, 255);
  }

  void Show(float min, float max)
  {
    if (pos.z >= min && pos.z <= max)
    {
      color c = color(0, zColor, zColor);
      //color c = color(0, 255, 255);
      stroke(c);
      point(pos.x, pos.y);//, pos.z);
    }
  }
}