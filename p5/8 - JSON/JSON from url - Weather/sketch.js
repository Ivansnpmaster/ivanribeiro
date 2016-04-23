var weather;

function setup()
{
	createCanvas(600, 400);
	
	// London city
	loadJSON("http://api.openweathermap.org/data/2.5/weather?q=London&APPID=d2c1e5900c507c9f9d09c49d55442a83", gotData, 'jsonp'); // Callbacks ! - jsonp for security!
}

function gotData(data)
{
	weather = data;
}

function draw()
{
	background(0);

	if(weather)
	{
		ellipse(width / 2, height / 2, weather.main.temp, weather.main.temp);
		ellipse(50, 100, weather.main.humidity, weather.main.humidity);
	}
}