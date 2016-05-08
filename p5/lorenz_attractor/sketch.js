// Ivan Ribeiro (@ivansnpmaster)
// Reference: https://en.wikipedia.org/wiki/Lorenz_system

// Positions
var x = 0.1;
var y = 0;
var z = 0;

// Formula angles
var sigma = 10;
var ro = 28;
var beta = 8 / 3.0;

// Delta t
var dt = 0.01;

var points = [];

// Runs once when program starts
function setup()
{
    // Creating the canvas
    createCanvas(450, 450);
    // Setting the color mode to Hue, Saturation, Brightness with a maximum values of 100
    colorMode(HSB);
    // Translating the (0,0) point to the middle of the screen
    translate(width / 2, height / 2);
    // Scaling everything to be 5 times bigger
    scale(5);
    // Making the thickness 1/5 skinny
    strokeWeight(0.2);
}

// Main loop
function draw()
{
    // Erasing everything
    background(0);
    // Make the shape just made by lines
    noFill();

    // Formula
    var dx = (sigma * (y - x)) * dt;
    var dy = (x * (ro - z) - y) * dt;
    var dz = (x * y - beta * z) * dt;

    x += dx;
    y += dy;
    z += dz;

    // Putting the points to the array
    points.push(createVector(x, y, z));

    var c = 0;

    // Starting the shape
    beginShape();

    for (var i = 0; i < points.length; i++)
    {
        stroke(c, 240, 240, 20);
        // Creating a vertex for every loop, if in 3D, add the 'z' component
        vertex(points[i].x, points[i].y);

        c += 0.05;
        // Reseting the color variable
        if (c > 255)
            c = 0;
    }
    endShape();
}

// Reseting if some key is pressed
function keyPressed()
{
    x = 0.1;
    y = 0;
    z = 0;
    points = [];

    background(0);
}