using System;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
public class Controller
{
    View view;
    public Board board;

    const int ROWS = 9;
    const int COLS = 9;
    public Controller(View view)
    {
        this.view = view;
        board = new Board(ROWS, COLS);
        view.CreateGrid(ref board, ROWS, COLS);
        SetBoard();

    }
    void SetBoard()
    {
        CreatePiece(new int2(0, 0), PieceType.Spear, Team.White);
        CreatePiece(new int2(0, 1), PieceType.Spear, Team.White);
    }
    void GenerateBoard()
    {

    }
    void CreatePiece(int2 coor, PieceType type, Team team)
    {
        Piece piece = type switch
        {
            PieceType.Pawn => new Pawn(coor, team),
            PieceType.Spear => new Spear(coor, team),
            PieceType.Horse => new Horse(coor, team),
            PieceType.Silver => new Silver(coor, team),
            PieceType.Gold => new Gold(coor, team),
            PieceType.Tower => new Tower(coor, team),
            PieceType.Bishop => new Bishop(coor, team),
            PieceType.King => new King(coor, team),

            _ => null
        };
        board.GetSquare(coor.x, coor.y).piece = piece;
        view.AddPiece(ref piece, coor);

    }
    ~Controller() { }


}
