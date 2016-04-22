var robot = [];

function setup()
{
	createCanvas(600, 400);

	robot[0] = new Robot(150, height / 3, 80);
	robot[0].firstRun();

	robot[1] = new Robot(300, height / 2, 20);
	robot[1].firstRun();

	robot[2] = new Robot(450, height - height / 2, 45);
	robot[2].firstRun();
}

function draw()
{
	background(190);

	for(var i = 0; i < robot.length; i ++)
	{
		robot[i].display();
	}
}

function mousePressed()
{
	var i = robot.length;
	robot[i] = new Robot(mouseX, mouseY, 60);
	robot[i].firstRun();
}

function Robot(x, y, bodyLenght)
{
	this.headR;
	this.bodySizeX;

	this.x = x;
	this.y = y;
	this.bodyLenght = bodyLenght;

	this.currentY = y;
	this.currentYSpeed = 1;

	this.ifCondition = 0;

	this.boxColor = {
		r : 0,
		g : 0,
		b : 0
	}

	this.firstRun = function()
	{
		this.boxColor.r = (random(0, 255));
		this.boxColor.g = (random(0, 255));
		this.boxColor.b = (random(0, 255));

		this.headR = random(30, 45);
		this.bodySizeX = random(45, 60);
		this.ifCondition = random(10, 40);
		this.line2X = this.x + 10;
		this.line3X = this.x + 20;
		this.spinVelocity = random(0, 0.1);
	}
	
	this.addHairFactor = 0;
	this.spinVelocity;

	this.line2X; // Line 2 from head to body
	this.line3X; // Line 3 from head to body

	this.display = function()
	{
		// Lines from head to body

		stroke(128);

		line(this.x, this.y, this.x, this.currentY + 100);
		line(this.line2X, this.y, this.line2X, this.currentY + 100);
		line(this.line3X, this.y, this.line3X, this.currentY + 100);

		// Hair

		for(var i = 0; i < 30; i ++)
		{
			line(this.x, this.y, this.x + this.headR * (cos(i + this.addHairFactor) * 1.1), this.y - this.headR * (sin(i + this.addHairFactor) * 1.1));
		}

		// Head

		noStroke();
		fill(this.boxColor.r, this.boxColor.g, this.boxColor.b);
		
		var headRTimes2 = this.headR * 2;
	
		ellipse(this.x, this.y, headRTimes2, headRTimes2);

		// Eyes

		fill(255);

		var headR2 = this.headR / 2;

		var dir = p5.Vector.sub(createVector(mouseX, mouseY), createVector(this.x, this.y));
		dir.normalize();
		dir.mult(headR2);

		ellipse(this.x + dir.x, this.y + dir.y, headR2, headR2);

		// Body

		this.currentY += 0.1 * this.currentYSpeed;

		fill(this.boxColor.r, this.boxColor.g, this.boxColor.b);
		rect(this.x - this.bodySizeX / 2, this.currentY + 100, this.bodySizeX, this.bodyLenght); // Body itself

		fill(this.boxColor.r - 20, this.boxColor.g - 20, this.boxColor.b - 20);
		rect(this.x - this.bodySizeX / 2, this.currentY + 101, this.bodySizeX - 1, this.bodyLenght - 1); // Corners of the body

		fill(this.boxColor.r - 50, this.boxColor.g - 50, this.boxColor.b - 50);
		rect(this.x - this.bodySizeX / 2, this.currentY + 100 + 10, this.bodySizeX - 1, 2); // Line in the middle of the body

		if (this.currentY > this.y + this.ifCondition || this.currentY < this.y - this.ifCondition) { this.currentYSpeed *= -1; }
		
		this.addHairFactor += this.spinVelocity;
	}
}