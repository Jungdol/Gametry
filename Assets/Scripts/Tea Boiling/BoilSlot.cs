using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoilSlot : MonoBehaviour, IDropHandler
{
    //스크립트 불러오기
    public BoliDragNDrop boliDragNDrop;
    public PotDragNDrop potDragNDrop;
    
    //화로에다 드랍
    public void OnDrop(PointerEventData eventData)
    {
        if((eventData.pointerDrag != null) && (boliDragNDrop.fireReady == true))
        {
            Debug.Log("뚜껑 올리기 완료!");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            boliDragNDrop.dontMove = true;
            potDragNDrop.BlazerReady = true;
        }
        else
        {
            boliDragNDrop.transform.position = boliDragNDrop.originPos;
            Debug.Log("불이 준비가 안됨!");
        }
    }
}
