using UnityEngine;

public class CementeryView : MonoBehaviour
{
    [SerializeField] CementeryCellView pawnView;
    [SerializeField] CementeryCellView spearView;
    [SerializeField] CementeryCellView horseView;
    [SerializeField] CementeryCellView silverView;
    [SerializeField] CementeryCellView goldView;
    [SerializeField] CementeryCellView towerView;
    [SerializeField] CementeryCellView bishopView;

    public void UpdateCellView(PieceType pieceType,int count)
    {
        switch (pieceType)
        {
            case PieceType.Pawn:
                pawnView.UpdateCountText(count);
                break;
            case PieceType.Spear:
                spearView.UpdateCountText(count);
                break;
            case PieceType.Horse:
                horseView.UpdateCountText(count);
                break;
            case PieceType.Silver:
                silverView.UpdateCountText(count);
                break;
            case PieceType.Gold:
                goldView.UpdateCountText(count);
                break;
            case PieceType.Tower:
                towerView.UpdateCountText(count);
                break;
            case PieceType.Bishop:
                bishopView.UpdateCountText(count);
                break;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
