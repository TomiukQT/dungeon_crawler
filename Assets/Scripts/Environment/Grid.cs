using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    private int _width;
    private int _heigth;
    private T[,] _data;

    public Grid(int width, int heigth)
    {
        
        _data = new T[width, heigth];
        _width = width;
        _heigth = heigth;
    }

    public T Get(int x, int y)
    {
        return CheckBounds(x,y) ? _data[x, y] : default(T);
    }

    private bool CheckBounds(int x, int y)
    {
        return x >= 0 && x < _width && y >= 0 && y < _heigth;
    }

}
