PeasyCam cam;
ControlP5 c1;
Slider slider;

// Image name for saving purposes
String[] imageName = { "Double Narcissus", "Beel", "Skull" };
int indexImg = 0;

final String SEPARATOR = "-----------------------------------";
final String FOLDERPATH = "Images/";
final int TEXTPADDING = 20;

void UI()
{
  textSize(15);

  surface.setTitle("Generating depth based on image colors");

  c1 = new ControlP5(this);
  slider = c1.addSlider("Scn").setBroadcast(true)
    .setPosition(srcImage.width + TEXTPADDING, 10)
    .setRange(0, 10)
    .setSize(150, 10)
    .setValue(cn)
    .setLabel("Coeficient of neighborhood");

  // Creating the camera for the movement
  //cam = new PeasyCam(this, 100);

  hasGenerated = false;
}

void Scn(int v)
{
  if (cn != v)
  {
    cn = v;
    hasGenerated = false;

    slider.setValue(cn);

    fill(255);
    rect(srcImage.width, -1, width - srcImage.width + 1, height); // Border purposes

    fill(0);
    text("Generating", srcImage.width + TEXTPADDING, TEXTPADDING * 2);
  }
}

void RepositionSlider()
{
  if (slider != null)
    slider.setPosition(srcImage.width + TEXTPADDING, 10);
}

void keyPressed()
{
  if (key == 's' || key == 'S')
    SaveImage();

  else if (key == '[' && hasGenerated)
    IncreaseCN();

  else if (key == ']' && cn > 0 && hasGenerated)
    DecreaseCN();

  else if (key == 'c' || key == 'C')
  {
    indexImg++;
    if (indexImg > imageName.length - 1)
      indexImg = 0;

    LoadImage(true);
  }
}

void LoadImage(boolean reajust)
{
  // Loading the database image
  srcImage = loadImage(imageName[indexImg] + ".jpg");
  // Getting the size of the image
  w = srcImage.width + srcImage.width / 2;
  h = srcImage.height;
  // Set the size to be the same of the picture

  surface.setSize(w, h);

  if (reajust)
  {
    hasGenerated = false;
    RepositionSlider();
  }
}

void SaveImage()
{
  println(SEPARATOR);
  
  String name = imageName[indexImg] + " with coeficient of neighborhood = " + cn + ".png" ;

  int imgW = srcImage.width;
  int imgH = srcImage.height;

  PImage saveImage = createImage(imgW, imgH, RGB);
  saveImage.loadPixels();

  for (int i = 0; i < imgW; i++)
  {
    for (int j = 0; j < imgH; j++)
    {
      float c = grid.GetDotHeight(i, j);
      if (c >= minDelimiter && c <= maxDelimiter)
        saveImage.pixels[i + j * imgW] = color(0, 140, 140);
      else
        saveImage.pixels[i + j * imgW] = color(191);
    }
  }

  saveImage.updatePixels();
  saveImage.save(FOLDERPATH + imageName[indexImg] + "/" + name);

  println("Image " + imageName[indexImg] + " saved!");
}

void IncreaseCN()
{
  String s = "Coeficient of neighborhood: " + cn + " increased to " + (cn + 1);
  println(s);

  Scn(cn + 1);

  fill(0);
  text(s, srcImage.width + TEXTPADDING, TEXTPADDING * 3, width - srcImage.width - TEXTPADDING, height);
}

void DecreaseCN()
{
  String s = "Coeficient of neighborhood: " + cn + " decreased to " + (cn - 1); 
  println(s);

  Scn(cn - 1);

  fill(0);
  text(s, srcImage.width + TEXTPADDING, TEXTPADDING * 3, width - srcImage.width - TEXTPADDING, height);
}