var widthEllipse = 50;

var circle = {
	x: 0,
	y: 0,
	diameter: 50
};

function setup()
{
  createCanvas(600, 400);
}

function draw()
{
	circle.x = mouseX;
	circle.y = mouseY;

	//background(0, 0, 100, 50); // Background color
	noStroke();
	fill(random(0, 255), random(0, 255), random(0, 255)); // Color inside - 4º argument 0 to 255: 0 is completly transparent, 255 fully opaque

	ellipse(circle.x + random(-5, 5), circle.y + random(-5, 5), circle.diameter + random(-5, 5), circle.diameter + random(-5, 5));
}

function mousePressed()
{
	stroke(0);
	fill(240);
	ellipse(mouseX + 75, mouseY + 75, widthEllipse, widthEllipse);
	ellipse(mouseX - 75, mouseY - 75, widthEllipse, widthEllipse);
	ellipse(mouseX - 75, mouseY + 75, widthEllipse, widthEllipse);
	ellipse(mouseX + 75, mouseY - 75, widthEllipse, widthEllipse);
}