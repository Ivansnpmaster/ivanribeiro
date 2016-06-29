/*
  Created by: Ivan Ribeiro
 Date: 05/2016 - Current
 */

class Grid
{
  int w;
  int h;
  PImage img;

  Dot[][] dots;
  ArrayList<Dot> visibleDots;

  Histogram histogram;
  Quadrant[][] quadrants;

  boolean showed = false;

  // Image source; Minimum and maximum height to display; Coeficient of neighborhood
  Grid(PImage _img, float min, float max, int cn)
  {
    println(SEPARATOR);
    println("Start generating");

    img = _img;
    w = img.width;
    h = img.height;

    dots = new Dot[w][h];
    visibleDots = new ArrayList<Dot>();

    for (int i = 0; i < w; i++)
      for (int j = 0; j < h; j++)
        dots[i][j] = new Dot(i, j, w);

    int maxIndex = w * h;

    // Check the neighbors to add the brightness
    for (int i = 0; i < w; i++)
      for (int j = 0; j < h; j++)
      {
        float total = 0;
        int arraySize = 0;
        ArrayList<Float> points = new ArrayList<Float>();

        // Getting the neighbors based on the coeficient of neighborhood
        for (int k = -cn; k <= cn; k++)
          for (int l = -cn; l <= cn; l++)
          {
            int indexX = i + k;

            if (indexX < 0)
              indexX = w + k;
            else if (indexX > w - 1)
              indexX = k - 1;

            int indexY = j + l;

            if (indexY < 0)
              indexY = h + l;
            else if (indexY > h - 1)
              indexY = l - 1;

            int index = indexX + indexY * w;

            if (index > -1 && index < maxIndex)
              points.add(GetBrightness(img.pixels[index]));
          }

        arraySize = points.size();

        for (int a = 0; a < arraySize; a++)
          total += points.get(a);

        total /= (float)arraySize;
        total = map(total, 0, 255, 0, 100);

        dots[i][j].Z(total);

        if (dots[i][j].Show(min, max))
          visibleDots.add(dots[i][j]);
      }

    println("Generating done");
    println(SEPARATOR);
    println("Image width: " + w + " - Image height: " + h);
    println("Image lenght: " + img.pixels.length);
    println("Visible pixels: " + visibleDots.size() + " - " + (visibleDots.size() / (float) img.pixels.length) * 100.0 + " %");

    println(SEPARATOR);

    histogram = new Histogram(visibleDots);

    // Starting with a prime number
    int maxQuadrantWidth = round(img.width / 10.0);
    int maxQuadrantHeight = round(img.height / 10.0);

    float mqw = (float) maxQuadrantWidth;
    float mqh = (float) maxQuadrantHeight;

    while (img.width % mqw != 0 && mqw % 1.0 != 0)
    {
      maxQuadrantWidth--;
      mqw--;

      if (maxQuadrantWidth < 2) break;
    }

    while (img.height % mqh != 0 && mqh % 1.0 != 0)
    { 
      maxQuadrantHeight--;
      mqh--;

      if (maxQuadrantHeight < 2) break;
    }

    quadrants = new Quadrant[w / maxQuadrantWidth][h / maxQuadrantHeight];

    int x = 0, y = 0;
    int limitX = w - maxQuadrantWidth + 1;
    int limitY = h - maxQuadrantHeight + 1;

    for (int i = 1; i <= limitX; i+= maxQuadrantWidth)
    {
      for (int j = 1; j <= limitY; j+= maxQuadrantHeight)
      {
        int startX = i - 1;
        int startY = j - 1;
        int endX = startX + maxQuadrantWidth - 1;
        int endY = startY + maxQuadrantHeight - 1;

        println("Starting (" + startX + ", " + startY + ") - Ending (" + endX + ", " + endY + ")");

        quadrants[x][y] = new Quadrant(dots, startX, startY, endX, endY);
        y++;
      }
      x++;
      y = 0;
    }

    println("0: " + quadrants[0].length);
    println("1: " + quadrants[1].length);

    for (int i = 0; i < quadrants[0].length; i++)
      for (int j = 0; j < quadrants[1].length; j++)
      {
        int sx = quadrants[i][j].startX;
        int sy = quadrants[i][j].startY;
        int ex = quadrants[i][j].endX;
        int ey = quadrants[i][j].endY;

        stroke(quadrants[i][j].c);

        ArrayList<Dot> d = new ArrayList<Dot>(quadrants[i][j].dots);

        for (int k = sx; k <= ex; k++)
          for (int m = sy; m <= ey; m++)
            for (int n = d.size() - 1; n >= 0; n--)
              if (d.get(n).pos.x == k && d.get(n).pos.y == m)
              {
                d.remove(n);
                point(k, m);
              }
      }
  }

  public void ShowHistogram()
  {
    histogram.ShowHistogram();
  }

  public void ShowIslands()
  {
    if (showed) return;

    showed = true;

    println(SEPARATOR);
    println("Starting the island connected pixels stuff!");

    ArrayList<Dot> v = new ArrayList<Dot>(visibleDots);

    ArrayList<Island> islands = new ArrayList<Island>();
    Agglomerate agg = new Agglomerate();

    while (v.size() > 0)
    {
      ArrayList<Dot> island = agg.GetConnectedPixels(v, this);
      islands.add(new Island(island));

      for (int i = 0; i < island.size(); i++)
      {
        for (int j = v.size() - 1; j >= 0; j--)
        {
          if (island.get(i).index == v.get(j).index)
            v.remove(j);
        }
      }
    }

    println(SEPARATOR);
    println("Painting points!");

    // For every island in islands
    for (int i = 0; i < islands.size(); i++)
    {
      stroke(random(255), random(255), random(255));
      // For every dot in current island
      for (int j = 0; j < islands.get(i).GetLength(); j++)
      {
        Dot d = islands.get(i).GetDot(j);
        point(d.pos.x, d.pos.y);
      }

      islands.get(i).ShowSize();
    }
    println("It's done!");
  }

  float GetBrightness(color c)
  {
    // Faster way of getting red
    int r = (c >> 16) & 0xFF;
    // Faster way of getting green
    int g = (c >> 8) & 0xFF;
    // Faster way of getting blue
    int b = c & 0xFF;

    return (r + g + b) / 3.0;
  }

  float GetDotHeight(int x, int y)
  {
    return dots[x][y].pos.z;
  }
}