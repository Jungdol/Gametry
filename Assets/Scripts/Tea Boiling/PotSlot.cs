using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotSlot : MonoBehaviour, IDropHandler
{
    //스크립트 불러오기
    public PotDragNDrop potDragNDrop;

    //오브젝트
    public GameObject BackToCon;
    public GameObject Pot;
    
    //화로에다 드랍
    public void OnDrop(PointerEventData eventData)
    {
        if((eventData.pointerDrag != null) && (potDragNDrop.BlazerReady == true))
        {
            Debug.Log("물 끓이기 완료!");
            eventData.pointerDrag.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            eventData.pointerDrag.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2 (GetComponent<RectTransform>().anchoredPosition.x + 20f, GetComponent<RectTransform>().anchoredPosition.y + 110f);
            potDragNDrop.dontMove = true;
            BackToCon.SetActive(true);
            Pot.transform.position = potDragNDrop.gameObject.transform.position; // 레이어 이동
            Pot.SetActive(true);
        }
        else
        {
            potDragNDrop.transform.position = potDragNDrop.originPos;
            Debug.Log("불이 준비가 안되었거나 뚜껑을 먼저 올려 놓지 않음!");
        }
    }
}

