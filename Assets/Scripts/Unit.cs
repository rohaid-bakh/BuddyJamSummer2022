using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Unit : MonoBehaviour, IDropHandler
{
    //TODO:: Test Grid Calculation/See if using the grid layout component + getting the rec max X and mmin Y can solve some issues
    //TODO:: Ensure no stacking on units.
    [SerializeField] 
    private RectTransform Map;
    [SerializeField]
    private TextMeshProUGUI DummyText;

    private RectTransform currSquare;
    [SerializeField]
    private RectTransform[] itemBarSpaces;
    [SerializeField]
    private RectTransform itemBar;
    float xPos;
    float yPos;

    public Locations currentItem;
    private MapHandler handler;
    private Vector2 coordinates = new Vector2();
    private GameObject currObject;
    void Start()
    {
        // Calculates which square it is in the grid.
        currSquare = GetComponent<RectTransform>();

             xPos = currSquare.anchoredPosition.x / currSquare.rect.width;
             yPos = currSquare.anchoredPosition.y / currSquare.rect.height;
            if (xPos > 0) {
                xPos  = Mathf.FloorToInt(xPos);
            } else {
                xPos = Mathf.CeilToInt(xPos);
            }
            if (yPos > 0){
                yPos = Mathf.FloorToInt(yPos);
            } else {
                yPos = Mathf.CeilToInt(yPos);
            }
            currentItem = Locations.None;
            coordinates.x = (int) xPos;
            coordinates.y = (int) yPos;

            //Grab so as to update.
            handler = FindObjectOfType<MapHandler>();
    }
    //in order to remove the data that the item is at the current location
    public void wipeLocation(){
            handler.deleteLocation(currentItem);
            currentItem = Locations.None;
            currObject = null;
    }

    public void resetMap(){
        currObject.GetComponent<RectTransform>().anchoredPosition = 
        itemBarSpaces[(int)currentItem].anchoredPosition + itemBar.anchoredPosition;
        currentItem = Locations.None;
        currObject = null;
    }

    public void OnDrop(PointerEventData data){
       
        if(data.pointerDrag != null){
            if(currentItem != Locations.None){
                
                data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                itemBarSpaces[(int)currentItem].anchoredPosition + itemBar.anchoredPosition; //write the code so its placed in the correct position

                
                return;
            }
            //snaps item to grid
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                currSquare.anchoredPosition + Map.anchoredPosition;
            currObject = data.pointerDrag;
            
            DragNDrop script = data.pointerDrag.GetComponent<DragNDrop>();
            //detail what is on the current square
            currentItem = script.details.type;
            //give the location to the item for updating purposes.
            script.currentLocation = this;

            //adding to dictionary new addition to map 
            handler.addLocation(currentItem, coordinates);

            //Test.Remove
            if(DummyText!= null){
            DummyText.text = "This will not be shown to the user.\n" +"The " +data.pointerDrag.GetComponent<DragNDrop>().details.type + " is " +  " \n At Square : " + xPos +  "," + yPos;
        }
                
        }
    }


}
