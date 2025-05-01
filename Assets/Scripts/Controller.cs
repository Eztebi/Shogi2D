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
        BlackPieces();
        WhitePieces();
    }
    void BlackPieces()
    {
        for(int i = 0; i < COLS; i++)
        {
            CreatePiece(new int2(i,2),PieceType.Pawn,Team.Black);
        }
        //spear
        CreatePiece(new int2(0, 0), PieceType.Spear, Team.Black);
        CreatePiece(new int2(8, 0), PieceType.Spear, Team.Black);
        //caballo
        CreatePiece(new int2(1, 0), PieceType.Horse, Team.Black);
        CreatePiece(new int2(7, 0), PieceType.Horse, Team.Black);
        //bishop
        CreatePiece(new int2(7, 1), PieceType.Bishop, Team.Black);
        //Torre
        CreatePiece(new int2(1, 1), PieceType.Tower, Team.Black);
        //Plateado
        CreatePiece(new int2(2, 0), PieceType.Silver, Team.Black);
        CreatePiece(new int2(6, 0), PieceType.Silver, Team.Black);
        //dorado
        CreatePiece(new int2(3, 0), PieceType.Gold, Team.Black);
        CreatePiece(new int2(5, 0), PieceType.Gold, Team.Black);
        //king
        CreatePiece(new int2(4, 0), PieceType.King, Team.Black);

    }
    void WhitePieces()
    {
        for (int i = 0; i < COLS; i++)
        {
            CreatePiece(new int2(i, 6), PieceType.Pawn, Team.White);
        }
        //spear
        CreatePiece(new int2(0, 8), PieceType.Spear, Team.White);
        CreatePiece(new int2(8, 8), PieceType.Spear, Team.White);
        //caballo
        CreatePiece(new int2(1, 8), PieceType.Horse, Team.White);
        CreatePiece(new int2(7, 8), PieceType.Horse, Team.White);
        //bishop
        CreatePiece(new int2(1, 7), PieceType.Bishop, Team.White);
        //Torre
        CreatePiece(new int2(7, 7), PieceType.Tower, Team.White);
        //Plateado
        CreatePiece(new int2(2, 8), PieceType.Silver, Team.White);
        CreatePiece(new int2(6, 8), PieceType.Silver, Team.White);
        //dorado
        CreatePiece(new int2(3, 8), PieceType.Gold, Team.White);
        CreatePiece(new int2(5, 8), PieceType.Gold, Team.White);
        //king
        CreatePiece(new int2(4, 8), PieceType.King, Team.White);


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
