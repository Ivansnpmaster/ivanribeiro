import peasy.*;
import controlP5.*;

// Grid of dots
Grid grid;

// Source image
PImage srcImage;

// Store the size of the image
int w;
int h;

// Minimum height to show dots depth
float minDelimiter = 30.0;

// Maximum height to show dots depth
float maxDelimiter = 100.0;

// Coeficient of neighborhood - Unprecision of the results (higher values makes the depth more like a plane)
int cn = 0;

boolean hasGenerated = false;

void setup()
{
  LoadImage(false);
  UI();

  background(191);
}

void draw()
{
  if (!hasGenerated)
  {
    background(191);
    hasGenerated = true;
    // Creating the grid
    grid = new Grid(srcImage, minDelimiter, maxDelimiter, cn);
  }
}