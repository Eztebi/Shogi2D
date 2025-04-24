
using System.Numerics;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
public struct Board
{
    public Square[,] grid;
    public Board(int row,int col)
    {
        grid = new Square[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                grid[i, j] = new Square(i, j);
            }
        }
    }
    public ref Square GetCoord(int row, int cols) => ref grid[row,cols];
}
public struct Square
{
    int2 coord;
    public Square(int posX, int posY)
    {
        coord = new int2(posX, posY);
    }   
    public int2 Coord  => coord;
}
