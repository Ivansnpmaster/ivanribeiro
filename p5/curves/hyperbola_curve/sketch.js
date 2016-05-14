/*
	Created by Ivan Ribeiro
	Date: 12/05/2016
	
	Project: Hyperbola curve
	Reference: http://www-history.mcs.st-andrews.ac.uk/Curves/Hyperbola.html
*/

// Array of points
var points = [];

// Radius of each part
var a = 5.0;
var b = 5.0;

// Runs once
function setup()
{
	// Creating the canvas
	createCanvas(300, 300);
	// Translating to the middle of the screen
	translate(width / 2, height / 2);
	// Changing the color of the line
	stroke(255);
	// Increasing stroke thickness
	strokeWeight(2);
}

// Main loop
function draw()
{
	// Erasing everything
	background(191);
	
	// Time variable
	var t = frameCount / 90.0;
	
	// Function
	var x = a * sec(t);
	var y = b * tan(t);
	
	// Making the variables with maximum of 3 characters after the dot
	x = x.toFixed(3);
	y = y.toFixed(3);
	
	// Adding the new point to the array
	points.push(createVector(x, y));

	// Removing the oldest one if the array becomes too large
	if (points.length > 625)
		points.splice(0, 1);
	
	// Drawing the points!
	for (var i = 0; i < points.length; i++)
		point(points[i].x, points[i].y);
}

// Secant function
function sec(v)
{
	return 1 / cos(v);
}

// Save the current frame if 's' key is pressed
function keyPressed()
{
	if(key == "s" || key == "S")
		save("Hyperbola - " + floor(random(9999999)) + ".png");
}