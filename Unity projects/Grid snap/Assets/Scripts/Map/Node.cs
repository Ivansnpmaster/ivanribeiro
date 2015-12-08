using UnityEngine;

public class Node
{
    public int x;
    public int z;
    public bool isOccuped;

    public Node(int _x, int _z, bool _isOccuped)
    {
        x = _x;
        z = _z;
        isOccuped = _isOccuped;
    }

    public Node()
    {
        x = 0;
        z = 0;
        isOccuped = false;
    }
}