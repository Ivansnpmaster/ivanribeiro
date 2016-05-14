/*
	Created by Ivan Ribeiro
	Date: 13/05/2016
*/

// Initial lenght
var l;

// Runs once
function setup()
{
	// Creating the canvas
	createCanvas(400, 400);
	// Translating to the bottom
	translate(width/2, height);
	// Nice brown color for the stroke
	stroke(160, 82, 45);
	// The current weight of the stroke
	strokeWeight(3);
	// Setting a random initial value
	l = random(100, 170);
	// Drawing the first part of the tree
	line(0, 0, 0, -l);
	// Translating to the end of the fisrt part of the tree
	translate(0, -l);
	// Start branching!
	branch(l);
}

function branch(len)
{
	// Reducing the size each time
	len *= 2/3;

	// The limit of the branching
	if (len < 20) return;

	// Browser! Remember everything I'll do right now
	push();
	// Rotation angle
	var a = random(PI/6, PI/4);
	rotate(a);
	// Setting some stroke weight by the size of the current lenght of the branch
	var t = map(len, 15, l, 0.1, 2.5);
	strokeWeight(t);
	// Drawing the line to the new position
	line(0, 0, 0, -len);
	// Translating to that position
	translate(0, -len);
	// Branch again!
	branch(len);
	// Ok browser, now you can let it go
	pop();

	// The same thing as above, but rotating in opposite direction
	push();
	a = random(-PI/6, -PI/4);
	rotate(a);
	strokeWeight(t);
	line(0, 0, 0, -len);
	translate(0, -len);
	branch(len);
	pop();	
}

function keyPressed()
{
	if (key == "s" || key == "S")
		save("Tree - " + floor(random(9999999999)) + ".png");
}