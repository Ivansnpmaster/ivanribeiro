/*
	Created by Ivan Ribeiro
	Date: 25/04/2016
	
	Project: Heart curve
	Reference: http://www.mathematische-basteleien.de/heart.htm
	
	x = 0.01 * (-pow(t, 2) + 40 * t + 1200) * sin(PI * t / 180);
	y = -0.01 * (-pow(t, 2) + 40 * t + 1200) * cos(PI * t / 180);
	0 <= t <= 60
	
	point(x, y);
	point(-x, y);
*/

// Scale
var heartScale = 6.0;

// Points of each side of the heart
var pointsA = [];
var pointsB = [];

// // Time variable
var t = 0;

// Runs once
function setup()
{
	// Creating the canvas
	createCanvas(400, 400);
	// Making everything smooth
	smooth();
	// Setting the frame rate to 24
	frameRate(24);
	
	// Erasing everything
	background(240);
	// Translating to the middle of the screen
	translate(width / 2, height / 2);
	// Removing the borders
	noStroke();
	// Making all drawings 
	noFill();
	// Adding the first vertex
	addVertex();
}

function draw()
{
	// Erasing everything
	background(240);
	
	// 0 <= t <= 60
	t = frameCount / 5.0;
	
	// Stopping the animation
	if (t >= 0 && t <= 60 && pointsA.length < 301)
		addVertex();
	
	// Heart color
	var c = map(mouseX, 0, width, 100, 255);

	// Fill the heart with the color above
	fill(c, 0, 0);
	
	// Start the drawing
	beginShape();
	for (var i = 0; i < pointsA.length; i++)
		vertex(pointsA[i].x, pointsA[i].y);
	endShape();
	
	beginShape();
	for (var i = 0; i < pointsB.length; i++)
		vertex(pointsB[i].x, pointsB[i].y);
	endShape();
}

function addVertex()
{
	// Coordinates
	var x = 0.01 * (-pow(t, 2) + 40 * t + 1200) * sin((PI * t) / 180);
	var y = -0.01 * (-pow(t, 2) + 40 * t + 1200) * cos((PI * t) / 180);
	
	// Making it bigger
	x *= heartScale;
	y *= heartScale;
	
	// Adding the new points
	pointsA.push(createVector(x, y));
	pointsB.push(createVector(-x, y));
}

// Save the current frame if 's' key is pressed
function keyPressed()
{
	if(key == "s" || key == "S")
		save("Heart - " + floor(random(9999999)) + ".png");
}