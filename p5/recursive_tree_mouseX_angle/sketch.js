var l;
var a = 0;

function setup()
{
	createCanvas(400, 400);
	background(191);

	l = floor(random(100, 150));
}

function draw()
{
	background(191);

	translate(width/2, height);
	strokeWeight(3);
	line(0, 0, 0, -l);
	translate(0, -l);

	a = map(mouseX, 0, width, PI/6, PI/3);

	branch(l);
}


function branch(len)
{
	len *= 2/3;

	if (len < 20) return;

	push();
	rotate(a);
	var t = map(len, 21, l, 0.1, 2.5);
	strokeWeight(t);
	line(0, 0, 0, -len);
	translate(0, -len);
	branch(len);
	pop();

	push();
	rotate(-a);
	t = map(len, 21, l, 0.1, 2.5);
	strokeWeight(t);
	line(0, 0, 0, -len);
	translate(0, -len);
	branch(len);
	pop();	
	
}