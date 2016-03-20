var circle = {
	x : 0,
	y : 0,
	diameter : 20,
	r : 10
};

var color = {
	r : 0,
	g : 0,
	b : 0
};

var speedX = 3;
var speedY = 3;

function setup()
{
	createCanvas(600, 400);

	circle.x = random(0, width);
	circle.y = random(0, height);

	speedX = random(-4, 4);
	speedY = random(-4, 4);

	color.r = random(0, 255);
	color.b = random(0, 255);
	color.g = random(0, 255);
}

function draw()
{
	background(0);

	noStroke();
	fill(color.r, color.g, color.b);

	ellipse(circle.x, circle.y, circle.diameter, circle.diameter);

	circle.x += speedX;
	circle.y += speedY;

	if (circle.x > width - circle.r || circle.x < 0 + circle.r)
	{
		speedX *= -1;

		color.r = random(0, 255);
		color.b = random(0, 255);
		color.g = random(0, 255);
	}

	if (circle.y > height - circle.r || circle.y < 0 + circle.r)
	{
		speedY *= -1;
		color.r = random(0, 255);
		color.b = random(0, 255);
		color.g = random(0, 255);
	}
}