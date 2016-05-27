PImage img;
int w;
int h;

String[] si = {
  "Double Narcissus - Squared.jpg", 
  "beel.jpg", 
  "Blue Hydrangea.jpg", 
  "Dahlia.jpg", 
  "flower.jpg", 
  "flower2.jpg", 
  "Morning Glory.jpg", 
  "rose.jpg", 
  "epiphyllum-oxypetalum.jpeg", 
  "huernia-zebrina.jpeg", 
  "skull.jpg"
};

int index = 0;

void setup()
{
  index = floor(random(0, si.length));

  background(0);
  LoadImage();
  noStroke();
}

void draw()
{
  for (int i = 0; i < 60; i++)
  {
    int xi = floor(random(width));
    int yi = floor(random(height));
    color c = img.pixels[xi + yi * w];

    fill(c);

    ellipse(xi, yi, 5, 5);
  }
}

void keyPressed()
{
  if (key == 'A' || key == 'a')
  {
    index++;
    if (index > si.length - 1)
      index = 0;

    LoadImage();

    background(0);
  }
}

void LoadImage()
{
  img = loadImage("Images/" + si[index]);
  w = img.width;
  h = img.height;
  surface.setSize(w, h);
}