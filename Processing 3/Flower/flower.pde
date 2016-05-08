float a = 0.0;
float b = 0.0;
float c = 0.0;

void setup()
{
  size(400, 400);
  background(0);
  colorMode(HSB, 100); // Mode and maximum value
  smooth();
}

void draw()
{
  float x0 = map(cos(a), -1, 1, 20, width - 20);
  float y0 = map(sin(a), -1, 1, 20, height - 20);

  float x1 = map(cos(b), -1, 1, 20, width - 20);
  float y1 = map(sin(b), -1, 1, 20, height - 20);

  stroke(c, 80, 80, 20); // color, saturation, brightness, alpha
  line(x0, y0, x1, y1);

  a += 0.02; // 0.02
  b += 0.07; // 0.07
  c += 1;

  if (c > 100) c = 0;
}

void keyPressed()
{
  background(0);
}