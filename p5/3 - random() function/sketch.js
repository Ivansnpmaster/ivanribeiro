var spot = {
	x : 0,
	y : 0
};

var color = {
	r : 0,
	g : 0,
	b : 0
};

function setup()
{
	createCanvas(600, 400);
	background(0);
}

function draw()
{
	spot.x = random(0, width);
	spot.y = random(0, height);

	color.r = random(100, 225);
	color.b = random(100, 190);

	noStroke();
	fill(color.r, 0, color.b, 50);

	ellipse(spot.x, spot.y, 15, 15);
}