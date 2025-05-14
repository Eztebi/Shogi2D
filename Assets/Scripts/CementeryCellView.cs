using TMPro;
using UnityEngine;

public class CementeryCellView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;

    public void UpdateCountText(int count)
    {
        countText.text = count.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countText=GetComponentInChildren<TextMeshProUGUI>();
        countText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
