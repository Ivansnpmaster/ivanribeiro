var vertices = [];

var recalculate = true;

function setup()
{
	createCanvas(640, 360);

	for(var i = 0; i < 10; i ++)
		vertices[i] = createVector(random(width), random(height));
}

function draw()
{
	if (!recalculate) return;

	recalculate = false;

	background(0);

	fill(255);
	stroke(255);

	var reached = [];
	var unreached = [];

	for(var i = 0; i < vertices.length; i ++)
		unreached.push(vertices[i]);

	reached.push(unreached[0]);
	unreached.splice(0, 1);

	while(unreached.length > 0)
	{
		var record = 1000;
		var rIndex;
		var uIndex;

		for (var i = 0; i < reached.length; i ++)
		{
			for (var j = 0; j < unreached.length; j ++)
			{
				var v1 = reached[i];
				var v2 = unreached[j];
				var d = dist(v1.x, v1.y, v2.x, v2.y);
			
				if (d < record)
				{
					record = d;
					rIndex = i;
					uIndex = j;
				}
			}
		}

		line(reached[rIndex].x, reached[rIndex].y, unreached[uIndex].x, unreached[uIndex].y)

		reached.push(unreached[uIndex]);
		unreached.splice(uIndex, 1);
	}

	noStroke();
	
	for(var i = 0; i < vertices.length; i ++)
		ellipse(vertices[i].x, vertices[i].y, 10, 10);
}

function mousePressed()
{
	recalculate = true;
	vertices.push(createVector(mouseX, mouseY));
}