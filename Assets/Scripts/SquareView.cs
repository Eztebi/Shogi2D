using TMPro;
using UnityEngine;

public class SquareView : MonoBehaviour
{
    TextMeshProUGUI text;
    string squareCoorText;
    
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetSquare(int x, int y)
    {
        squareCoorText = $"{x},{y}";
        text.text = squareCoorText;
    }

    public void AddPiece(ref Piece piece)
    {
        switch (piece.type) {
            case PieceType.Pawn:
                text.text = "P";
                break;
            case PieceType.Spear:
                text.text = "S";
                break;
            case PieceType.Horse:
                text.text = "H";
                break;
            case PieceType.Silver:
                text.text= "Si";
                break;
            case PieceType.Gold:
                text.text = "G";
                break;
            case PieceType.Tower:
                text.text = "T";
                break;
            case PieceType.Bishop:
                text.text = "B";
                break;
            case PieceType.King:
                text.text = "K";
                break;
        }
        switch (piece.team) {
            case Team.White:
                text.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Team.Black:
                text.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
        }
    }

    public void RemovePiece()
    {
        text.text=squareCoorText;
        text.gameObject.transform.rotation=Quaternion.Euler(0, 0,0);
    }
}
