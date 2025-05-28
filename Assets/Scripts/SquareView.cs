using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SquareView : MonoBehaviour
{
    TextMeshProUGUI text;
    string squareCoorText;
    [SerializeField] Image imageComponent;
    View view;
    Button buttonComponent;
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

    [Header("Upgraded sprites")]
    [SerializeField] Sprite UppawnSprite;
    [SerializeField] Sprite UpspearSprite;
    [SerializeField] Sprite UphorseSprite;
    [SerializeField] Sprite UpsilverSprite;
    [SerializeField] Sprite UptowerSprite;
    [SerializeField] Sprite UpbishopSprite;

    int2 gridPos;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        buttonComponent = GetComponent<Button>();
        imageComponent.enabled = false;
    }

    public void SetSquare(int x, int y,View view)
    {
        this.view = view;
        //squareCoorText = $"{x},{y}";
        gridPos=new int2(x,y);
        text.text = $"{x},{y}";
        
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
            PieceType.UpPawn => UppawnSprite,
            PieceType.UpSpear => UpspearSprite,
            PieceType.UpHorse => UphorseSprite,
            PieceType.UpSilver => UpsilverSprite,
            PieceType.UpTower => UptowerSprite,
            PieceType.UpBishop => UpbishopSprite,
            _ =>null
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

    private void OnEnable()
    {
        buttonComponent.onClick.AddListener(OnSelectSquare);
    }

    private void OnDisable()
    {
        buttonComponent.onClick.RemoveListener(OnSelectSquare);
    }
    void OnSelectSquare()
    {
        view?.SelectSquare(gridPos);
    }
}
