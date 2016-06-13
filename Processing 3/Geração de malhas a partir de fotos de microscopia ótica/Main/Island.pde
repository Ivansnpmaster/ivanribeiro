/*
  Created by: Ivan Ribeiro
  Date: 05/2016 - Current
*/

class Island
{
  ArrayList<Dot> connectedDots;

  Island(ArrayList<Dot> dots)
  {
    connectedDots = dots;
  }

  public int GetLength()
  {
    return connectedDots.size();
  }

  public Dot GetDot(int index)
  {
    if (index < connectedDots.size())
      return connectedDots.get(index);
    return null;
  }

  public void ShowSize()
  {
    println("Island size: " + GetLength());
  }
}