using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Unit : MonoBehaviour, IDropHandler
{
    //TODO:: Test Grid Calculation/See if using the grid layout component + getting the rec max X and mmin Y can solve some issues
    [SerializeField] 
    private RectTransform Map;
    [SerializeField]
    private TextMeshProUGUI DummyText;
    private RectTransform currSquare;
    float xPos;
    float yPos;
    void Start()
    {
        // Calculates which square it is in the grid.
        currSquare = GetComponent<RectTransform>();

             xPos = currSquare.anchoredPosition.x / currSquare.rect.width;
             yPos = currSquare.anchoredPosition.y / currSquare.rect.height;
            if (xPos > 0) {
                xPos  = Mathf.CeilToInt(xPos);
            } else {
                xPos = Mathf.FloorToInt(xPos);
            }
            if (yPos > 0){
                yPos = Mathf.CeilToInt(yPos);
            } else {
                yPos = Mathf.FloorToInt(yPos);
            }
            
    }
    public void OnDrop(PointerEventData data){
       
        if(data.pointerDrag != null){
            //snaps item to grid
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                currSquare.anchoredPosition + Map.anchoredPosition;

                //Testing purposes only
            DummyText.text = "This will not be shown to the user. \n At Square : " + xPos +  "," + yPos;
        }
    }
}
