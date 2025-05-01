using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquareView : MonoBehaviour
{
    TextMeshProUGUI text;
    string squareCoorText;
    [SerializeField]Image imageComponent;

    [Header("Sprites")]
    [SerializeField] Sprite pawnSprite;
    [SerializeField] Sprite spearSprite;
    [SerializeField] Sprite horseSprite;
    [SerializeField] Sprite silverSprite;
    [SerializeField] Sprite goldSprite;
    [SerializeField] Sprite towerSprite;
    [SerializeField] Sprite bishopSprite;
    [SerializeField] Sprite kingWhiteSprite;
    [SerializeField] Sprite kingBlackSprite;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        imageComponent.enabled = false;
    }

    public void SetSquare(int x, int y)
    {
        squareCoorText = $"{x},{y}";
        text.text = squareCoorText;
    }

    public void AddPiece(ref Piece piece)
    {
        text.enabled = false;
        imageComponent.enabled = true;

        imageComponent.sprite = piece.type switch
        {
            PieceType.Pawn => pawnSprite,
            PieceType.Spear => spearSprite,
            PieceType.Horse => horseSprite,
            PieceType.Silver => silverSprite,
            PieceType.Gold => goldSprite,
            PieceType.Tower => towerSprite,
            PieceType.Bishop => bishopSprite,
            PieceType.King => piece.team==Team.White ? kingWhiteSprite : kingBlackSprite,
            _=>null
        };
       imageComponent.gameObject.transform.rotation = piece.team switch { 
           Team.White => Quaternion.Euler(0,0,0),
           Team.Black => Quaternion.Euler(0,0,180),
           _ =>Quaternion.identity
       };
        
    }

    public void RemovePiece()
    {
        text.enabled = true;
        imageComponent.enabled = false;
    }
}
