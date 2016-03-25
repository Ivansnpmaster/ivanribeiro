var sliders = [];
var angle = 0;

function setup()
{
	noCanvas();

	for(var i = 0; i < 150; i ++)
	{
		sliders[i] = createSlider(0, 255, 50);
	}
}

function draw()
{
	var offset = 0;

	for(var i = 0; i < sliders.length; i ++)
	{
		var x = map(sin(angle + offset), -1, 1, 0, 255);
		sliders[i].value(x);
		offset += 0.025;
	}

	angle += 0.1;
}