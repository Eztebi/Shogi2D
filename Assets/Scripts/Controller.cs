using System;
using UnityEngine;
public class Controller
{
    View view;
    public Board board;

    const int ROWS = 9;
    const int COLS = 9;
    public Controller(View view)
    {
        this.view = view;
        board = new Board(ROWS,COLS);
        view.CreateGrid(ref board,ROWS,COLS);
        Debug.Log("Hello ");
    }
    ~Controller() { }


}
