/*
  Created by: Ivan Ribeiro
  Date: 05/2016 - Current
*/

PeasyCam cam;
ControlP5 c1;
Slider cnSlider;

public void UI()
{
  textSize(15);

  surface.setTitle("Generating depth based on image colors");

  c1 = new ControlP5(this);
  cnSlider = c1.addSlider("ChangeCoeficientOfNeighborhood").setBroadcast(true)
    .setPosition(srcImage.width + TEXTPADDING, 10)
    .setRange(0, 10)
    .setSize(150, 10)
    .setValue(cn)
    .setLabel("Coeficient of neighborhood");


  // Creating the camera for the movement
  //cam = new PeasyCam(this, 100);

  hasGenerated = false;
}

public void ChangeCoeficientOfNeighborhood(int v)
{
  if (cn != v)
  {
    cn = v;
    hasGenerated = false;

    cnSlider.setValue(cn);

    fill(255);
    rect(srcImage.width, -1, width - srcImage.width + 1, height); // Border purposes

    fill(0);
    text("Generating...", srcImage.width + TEXTPADDING, TEXTPADDING * 2);
  }
}

public void RepositionSlider()
{
  if (cnSlider != null)
    cnSlider.setPosition(srcImage.width + TEXTPADDING, 10);
}

public void keyPressed()
{
  if (key == 's' || key == 'S')
    SaveImage();

  else if (key == '[' && hasGenerated)
    IncreaseCN();

  else if (key == ']' && cn > 0 && hasGenerated)
    DecreaseCN();

  else if (key == 'a' || key == 'A' && hasGenerated)
    grid.ShowIslands();
    
  else if (key == 'h' || key == 'H')
    grid.ShowHistogram();
    
  else if (key == 'c' || key == 'C')
  {
    indexImg++;
    if (indexImg > imageName.length - 1)
      indexImg = 0;

    LoadImage(true);
  }
}

public void LoadImage(boolean reajust)
{
  // Loading the database image
  srcImage = loadImage("Resources/" + imageName[indexImg] + ".jpg");
  //srcImage.resize(450, 450);
  srcImage.resize(450, 0);

  // Getting the size of the image to reajust the window size
  int wi = srcImage.width + floor(srcImage.width * 0.75);
  int he = srcImage.height;

  // Set the size to be the same of the picture
  surface.setSize(wi, he);

  if (reajust)
  {
    hasGenerated = false;
    RepositionSlider();
  }
}

public void SaveImage()
{
  println(SEPARATOR);

  String name = imageName[indexImg] + " with coeficient of neighborhood = " + cn + ".png" ;

  int imgW = srcImage.width;
  int imgH = srcImage.height;

  PImage saveImage = createImage(imgW, imgH, RGB);

  saveImage.loadPixels();
  loadPixels();

  for (int i = 0; i < imgW; i++)
  {
    for (int j = 0; j < imgH; j++)
    {
      float c = grid.GetDotHeight(i, j);
      if (c >= minDelimiter && c <= maxDelimiter)
        saveImage.pixels[i + j * imgW] = pixels[i + j * width];
      else
        saveImage.pixels[i + j * imgW] = color(191);
    }
  }

  saveImage.updatePixels();
  saveImage.save(FOLDERPATH + imageName[indexImg] + "/" + name);

  println("Image " + imageName[indexImg] + " saved!");
}

public void IncreaseCN()
{
  String s = "Coeficient of neighborhood: " + cn + " increased to " + (cn + 1);
  println(s);

  ChangeCoeficientOfNeighborhood(cn + 1);

  fill(0);
  text(s, srcImage.width + TEXTPADDING, TEXTPADDING * 3, width - srcImage.width - TEXTPADDING, height);
}

public void DecreaseCN()
{
  String s = "Coeficient of neighborhood: " + cn + " decreased to " + (cn - 1); 
  println(s);

  ChangeCoeficientOfNeighborhood(cn - 1);

  fill(0);
  text(s, srcImage.width + TEXTPADDING, TEXTPADDING * 3, width - srcImage.width - TEXTPADDING, height);
}