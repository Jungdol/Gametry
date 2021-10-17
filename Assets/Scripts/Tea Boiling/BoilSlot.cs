using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoilSlot : MonoBehaviour, IDropHandler
{
    //스크립트 불러오기
    public BoliDragNDrop boliDragNDrop;
    
    //화로에다 드랍
    public void OnDrop(PointerEventData eventData)
    {
        if((eventData.pointerDrag != null) && (boliDragNDrop.fireReady == true))
        {
            Debug.Log("물 끓이기 완료!");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            boliDragNDrop.dontMove = true;
        }
        else
        {
            boliDragNDrop.transform.position = boliDragNDrop.originPos;
            Debug.Log("불이 준비가 안됨!");
        }
    }
}
