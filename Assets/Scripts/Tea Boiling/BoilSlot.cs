using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoilSlot : MonoBehaviour, IDropHandler
{
    //스크립트 불러오기
    public BoliDragNDrop boliDragNDrop;
    public PotDragNDrop potDragNDrop;
    // 불
    public GameObject fire;

    //화로에다 드랍
    public void OnDrop(PointerEventData eventData)
    {
        if((eventData.pointerDrag != null) && (boliDragNDrop.fireReady == true))
        {
            Debug.Log("뚜껑 올리기 완료!");
            eventData.pointerDrag.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            eventData.pointerDrag.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y + 20f);
            boliDragNDrop.dontMove = true;
            potDragNDrop.BlazerReady = true;

            fire.transform.position = boliDragNDrop.gameObject.transform.position;
            fire.SetActive(true); // 불 애니메이션 적용
        }
        else
        {
            boliDragNDrop.rectTransform.localPosition = boliDragNDrop.originPos;
            Debug.Log("불이 준비가 안됨!");
        }
    }
}
