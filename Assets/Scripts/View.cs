using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class View : MonoBehaviour
{
    Controller controller;
    [SerializeField] GameObject cellPrefab;
    [SerializeField] Transform parentGrid;
    private void Awake()
    {
        controller = new Controller(this);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateGrid(ref Board board,int rows, int cols)
    {
       // if (controller == null) { return; }

        for (int i = 0; i < rows ; i++)
        {
            for (int j = 0; j < cols; j++) 
            {
                GameObject newSquare = Instantiate(cellPrefab, parentGrid);
                int2 coor = board.GetCoord(i, j).Coord;
                newSquare.GetComponentInChildren<TextMeshProUGUI>().text=$"{coor.x},{coor.y}";
            }
        }
    }
}
