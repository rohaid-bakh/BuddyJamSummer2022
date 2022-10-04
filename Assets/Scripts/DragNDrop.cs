using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragNDrop : MonoBehaviour, IPointerDownHandler , IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    //TODO:: Add clamping to the items so they can only be within the area of the box or the grid. 
    private RectTransform trans;
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup group;

    [SerializeField]
    public Location details;

    public Unit currentLocation;

    [SerializeField]
    private RectTransform[] itemBar;

    [SerializeField]
    private RectTransform itemBarPlace;

    private void Awake() {
       trans = GetComponent<RectTransform>(); 
       group = GetComponent<CanvasGroup>();
    }
    //Don't think this is necessary but too afraid to remove
    public void OnPointerDown(PointerEventData eventData){
    }

    public void OnDrag(PointerEventData eventData){
        //getting change of position of the square / by the scale of the canvas
        //Without it the square might not be at the right place.
        trans.anchoredPosition += (eventData.delta/canvas.scaleFactor);
        if (currentLocation != null){
            //to clear out a unit when the item is moved around.
            currentLocation.wipeLocation();
            currentLocation = null;
        }
        
    }

    public void resetIcons(){
        if(currentLocation != null){
            currentLocation.resetMap();
            currentLocation = null;
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        group.blocksRaycasts = false;
    }
    
    public void OnEndDrag(PointerEventData eventData){
        //allows the unit script/ui to detect the item
         group.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            Debug.Log($"Item Number : {(int)(details.type)}");
            Debug.Log($"Item Location : {itemBar[(int)(details.type)].anchoredPosition}");
            Debug.Log($"ItemBar Location: {itemBarPlace.anchoredPosition}");
            GameObject otherItem = eventData.pointerDrag;
            Location itemTypes = otherItem.GetComponent<DragNDrop>().details;
            otherItem.GetComponent<RectTransform>().anchoredPosition = 
            itemBar[(int)(itemTypes.type)].anchoredPosition + itemBarPlace.anchoredPosition;

        }
    }
    
}
