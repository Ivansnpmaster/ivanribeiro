class Grid
{
  int w;
  int h;
  PImage img;
  PImage modifiedImage;
  Dot[][] dots;

  // Image source; Minimum and maximum height to display; Coeficient of neighborhood
  Grid(PImage _img, float min, float max, int cn)
  {
    println(SEPARATOR);
    println("Start generating");

    img = _img;
    w = img.width;
    h = img.height;

    dots = new Dot[w][h];

    for (int i = 0; i < w; i++)
      for (int j = 0; j < h; j++)
        dots[i][j] = new Dot(i, j);

    int maxIndex = w * h;

    // Check the neighbors to add the brightness
    for (int i = 0; i < w; i++)
    {
      for (int j = 0; j < h; j++)
      {
        float total = 0;
        int arraySize = 0;
        ArrayList<Float> points = new ArrayList<Float>();

        // Getting the neighbors based on the coeficient of neighborhood
        for (int k = -cn; k <= cn; k++)
        {
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
        }

        arraySize = points.size();

        for (int a = 0; a < arraySize; a++)
          total += points.get(a);

        total /= (float)arraySize;
        total = map(total, 0, 255, 0, 100);

        dots[i][j].Z(total);
      }
    }

    println("Generating done");
    println(SEPARATOR);
    println("Image width: " + w + " - Image height: " + h);
    println("Image lenght: " + img.pixels.length);
    println(SEPARATOR);
    println("Start displaying");

    ShowGrid(min, max);

    println("Display done");
  }

  // Show the grid
  void ShowGrid(float min, float max)
  {
    for (int x = 0; x < w; x++)
      for (int y = 0; y < h; y++)
        dots[x][y].Show(min, max);
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