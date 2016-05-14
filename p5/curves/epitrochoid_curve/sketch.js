/*
	Created by Ivan Ribeiro
	Date: 12/05/2016
	
	Project: Epitrochoid curve
	Reference: http://www-history.mcs.st-andrews.ac.uk/Curves/Epitrochoid.html
*/

// Scale
var w = 5.0;
// Array of points
var points = [];

// Formula constants (Changing this values makes the curve looks different!)
var a = 3.0;
var b = 5.0;
var c = 10.0; // Spacement

// Runs once
function setup()
{
	// Creating the canvas
	createCanvas(400, 400);
	// Translating to the middle of the screen
	translate(width / 2, height / 2);
	// Setting the frame rate to 24
	frameRate(24);
	// Making the drawings empty (Just made by lines)
	noFill();
	// Color of the line
	stroke(255);
}

// Main loop
function draw()
{
	// Erasing everything
	background(191);
	
	// Time variable
	var t = frameCount / 10.0;
	
	// Formula
	var x = (a + b) * cos(t) - c * cos((a / b + 1) * t);
	var y = (a + b) * sin(t) - c * sin((a / b + 1) * t);
	
	// Making the variables with maximum of 3 characters after the dot
	x = x.toFixed(3);
	y = y.toFixed(3);
	
	// Adding the new point to the array
	points.push(createVector(x * w, y * w));
	
	// Removing the oldest one if the array becomes too large
	if (points.length > 315)
		points.splice(0, 1);

	// Drawing the curve!
	beginShape();
	for (var i = 0; i < points.length; i++)
		vertex(points[i].x, points[i].y);
	endShape();
}

// Save the current frame if 's' key is pressed
function keyPressed()
{
	if(key == "s" || key == "S")
		save("Epitrochoid - " + floor(random(9999999)) + ".png");
}