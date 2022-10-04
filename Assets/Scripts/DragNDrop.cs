using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragNDrop : MonoBehaviour, IPointerDownHandler , IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //TODO:: Add clamping to the items so they can only be within the area of the box or the grid. 
    private RectTransform trans;
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup group;

    [SerializeField]
    public Location details;

    public Unit currentLocation;

    //bool for sound manager
    public SoundManager soundManagerReference;
    //public bool clickSoundOn;

    private void Awake() {
       trans = GetComponent<RectTransform>(); 
       group = GetComponent<CanvasGroup>();
    }
    //Don't think this is necessary but too afraid to remove
    public void OnPointerDown(PointerEventData eventData){
        //added this to make click sound
        soundManagerReference.clickSoundOn = true;

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

    public void OnBeginDrag(PointerEventData eventData){
        group.blocksRaycasts = false;
    }
    
    public void OnEndDrag(PointerEventData eventData){
        //allows the unit script/ui to detect the item
         group.blocksRaycasts = true;
        //added sound for when you drop icon
         Debug.Log("Upsound");
        soundManagerReference.dropSoundOn = true;
    }
    
}
