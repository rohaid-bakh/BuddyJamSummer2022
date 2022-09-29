using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragNDrop : MonoBehaviour, IPointerDownHandler , IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform trans;
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup group;

    private void Awake() {
       trans = GetComponent<RectTransform>(); 
       group = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData){
       Debug.Log("PointerDown");
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("Moving Around");
        trans.anchoredPosition += (eventData.delta/canvas.scaleFactor);
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        group.blocksRaycasts = false;
        Debug.Log("Started Dragging");
    }
    
    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("Stopped Dragging");
         group.blocksRaycasts = true;
    }
    
}
