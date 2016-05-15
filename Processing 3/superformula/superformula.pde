/*
  Created by Ivan Ribeiro
  Date: 15/05/2016
  
  Special thanks to Alexander Miller
  Reference: https://www.youtube.com/watch?v=u6arTXBDYhQ
*/

// Time variable
float t = 0;

void setup()
{
  // Creating the canvas
  size(500, 500);
  // Making the shape just made by lines
  noFill();
  // Color of the lines
  stroke(255);
  // Thickness of the lines
  strokeWeight(2);
}

void draw()
{
  // Erasing everything
  background(0);
  
  // Translating to the middle of the screen
  translate(width / 2, height / 2);
  
  // Start the drawing!
  beginShape();
  
  for (float theta = 0; theta <= TWO_PI; theta += 0.1)
  {
    float rad = R(theta,
    2, // Size of the shape and the bottom part of the shape
    2, // If (m != 0) b changes the top part of the shape 
    6, // Number of spikes
    1, // Larger values makes the shape smoother
    sin(t) + 0.5, // Modifies the actual shape
    cos(t) + 0.5 // Modifies the actual shape
    );
    
    // Polar to cartesian
    float x = X(rad, theta);
    float y = Y(rad, theta);
    
    // Scaling the cartesian coordinates
    x *= 50;
    y *= 50;
    
    // Creating the vertex
    vertex(x, y);
  }

  endShape(CLOSE);
  
  // Increasing the parameter time
  t += 0.1;
}

// Superformula function
float R(float theta, float a, float b, float m, float n1, float n2, float n3)
{
  float part1 = pow(abs(cos(m * theta / 4.0) / a), n2);
  float part2 = pow(abs(sin(m * theta / 4.0) / b), n3);
  
  return pow(part1 + part2, -1.0 / n1);
}

// Converting the polar coordinates to cartesian coordinates
float X(float r, float a)
{
  return r * cos(a);
}

// Converting the polar coordinates to cartesian coordinates
float Y(float r, float a)
{
  return r * sin(a);
}