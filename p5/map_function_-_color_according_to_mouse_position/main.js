var color = {
	r : 0,
	b : 0
};

function setup()
{
  createCanvas(600, 400);
}

function draw()
{
	// map function (what I want to check, min, max, min, max)

	color.r = map(mouseX, 0, 600, 0, 255);
	color.b = map(mouseY, 0, 400, 0, 255);

	background(0);
	noStroke();
	fill(color.r, 0, color.b);
	ellipse(mouseX, mouseY, 50, 50);
}