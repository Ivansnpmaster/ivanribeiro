/*
  Created by: Ivan Ribeiro
  Date: 05/2016 - Current
*/

class Agglomerate
{
  // Depth First Search algorithm implementation
  ArrayList<Dot> GetConnectedPixels(ArrayList<Dot> dots, Grid grid)
  {
    ArrayList<Dot> stack = new ArrayList<Dot>();
    ArrayList<Dot> result = new ArrayList<Dot>();

    if (dots.size() <= 0) return result;

    Dot first = dots.get(0);
    first.visited = true;
    stack.add(first);
    grid.dots[(int) first.pos.x][(int) first.pos.y] = first;

    result.add(stack.get(0));
    
    while (stack.size() > 0)
    {
      //println("Aggomerate: " + stack.size());
      
      // Get unvisited adjacents
      ArrayList<Dot> adjacents = stack.get(stack.size() - 1).GetNeighbors(dots, grid);

      if (adjacents.size() > 0)
      {
        stack.add(adjacents.get(0));

        Dot l = stack.get(stack.size() - 1);
        l.visited = true;
        
        grid.dots[(int) l.pos.x][(int) l.pos.y] = l;

        result.add(stack.get(stack.size() - 1));
      }
      else
        stack.remove(stack.size() - 1);
    }
    return result;
  }
}