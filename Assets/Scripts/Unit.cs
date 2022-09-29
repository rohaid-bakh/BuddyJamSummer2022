using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data){
        if(data.pointerDrag != null){
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
            GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
