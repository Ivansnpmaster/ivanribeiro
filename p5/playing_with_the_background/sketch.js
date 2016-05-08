var slider;

function setup()
{
	createCanvas(600, 400);
	textSize(15);

	slider = createSlider(0, 255, 0); // min, max and default value
	slider.position(20, 20);
	slider.style('width', '540px');
}

function draw()
{
	var c = slider.value();
	background(c);
}

function mousePressed()
{
	save('myCanvas.jpg');
}