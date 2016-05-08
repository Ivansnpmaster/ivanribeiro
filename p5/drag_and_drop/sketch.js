var dropzone;

function setup()
{
	createCanvas(400, 400);
	background(0);

	dropzone = select('#dropzone');
	dropzone.dragOver(highlight);
	dropzone.dragLeave(unhighlight);
	dropzone.drop(gotFile, unhighlight); //  When the file gets loaded, when the user drops
}

function gotFile(file)
{
	createP(file.name + '	' + file.size);

	var img = createImg(file.data);
	img.size(100, 100);
}

function highlight()
{
	dropzone.style('background-color', '#333');
}

function unhighlight()
{
	dropzone.style('background-color', '#FFF');
}