var pos;

var bodyHeight = 120;
var bodyWidth = 60;

var footWidth = 60;
var footHeight = 30;

var headRadius = 60;

var origin;
var mover;

var padd = 5;

var angle;

var aAcceleration;
var aVelocity = 0.0;
var pendulumLenght = 25;

var gravity = -0.15;

function setup()
{
	createCanvas(320, 280);
	
	background(220);
	
	initializeVariables();
}

function draw()
{
	//background(0);

	noStroke();

	fill(92, 64, 51);
	rect(pos.x - bodyWidth * 0.5, pos.y, bodyWidth, bodyHeight);

	fill(92, 50, 30);
	rect(pos.x - bodyWidth * 0.5 + padd, pos.y, insideBodyWidth, bodyHeight_2_T_padd);

	aAcceleration = g_pendulum * sin(angle);
	aVelocity += aAcceleration;
	angle += aVelocity;

	mover = createVector(pendulumLenght * sin(angle), pendulumLenght * cos(angle));

	fill(254, 153, 0);
	stroke(254, 153, 0);
	line(origin.x, origin.y, mover.x + origin.x, mover.y + origin.y + bodyHeight * 0.5); // Line to Mover

	ellipse(mover.x + origin.x, mover.y + originY_plus_bodyHeight_T_half, 10, 10); // Mover

	noStroke();
	fill(92, 64, 51);
	ellipse(pos.x, pos.y, headRadius, headRadius); // Big head

	fill(240);
	ellipse(pos.x, pos.y, headRadius - padd, headRadius - padd); // Head inside the big head

	fill(92, 64, 51);
	rect(footX, footY, footWidth, footHeight); 
}

// Const variables at runtime

var insideBodyWidth;
var footX;
var footY;

var bodyHeight_2_T_padd;
var g_pendulum;
var originY_plus_bodyHeight_T_half;

function initializeVariables()
{
	pos = createVector(width / 2, height / 2);
	mover = pos.copy();
	origin = pos.copy();
	angle  = PI / 6;

	insideBodyWidth = bodyWidth - 2 * padd;
	footX = origin.x - bodyWidth * 0.6;
	footY = pos.y + bodyHeight * 0.95;
	footWidth = bodyWidth * 1.2;

	bodyHeight_2_T_padd = bodyHeight - 2 * padd;
	g_pendulum = gravity / pendulumLenght;
	originY_plus_bodyHeight_T_half = origin.y + bodyHeight * 0.5;
}