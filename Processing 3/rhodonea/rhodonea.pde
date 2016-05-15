// Constant variable that sets the shape
float k = 5/9.0;

// Runs once
void setup()
{
  // Creating the canvas
  size(400, 400);
  // Stroke color
  stroke(255, 0, 0);
  // Stroke thickness
  strokeWeight(5);
  // Smoothing the drawing
  smooth();
  // Erasing everything with white color
  background(255);
}

// Main loop
void draw()
{
  // Time variable
  float t = frameCount / 100.0;
  // Cartesian coordiantes
  float x = map(cos(k * t) * sin(t), -1, 1, 20, width - 20);
  float y = map(cos(k * t) * cos(t), -1, 1, 20, height - 20);
  
  // Creating the point
  point(x, y);
}