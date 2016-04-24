void setup()
{
  size(400, 400);
  background(255);
  smooth();
  noFill();
}

void draw()
{
  background(255);
  float t = frameCount / 500.0;
  
  for (int i = 0; i < 30; i++)
  {
    bezier( //(pointA, referenceA, referenceB, pointB)
    width / 2, height,
    width / 2, noise(1, i, t) * height,
    noise(2, i, t) * width, noise(3, i, t) * height,
    noise(4, i, t) * width, noise(5, i, t) * height);
  }
}