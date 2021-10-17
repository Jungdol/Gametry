using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopDragNDrop : MonoBehaviour
{
    //버튼 드래그 떄 필요한 것들
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    //예외 처리 변수
    public bool dontMove = false;
    public bool fireReady = false;

    //오브젝트의 원래 위치 변수
    public Vector3 originPos;

    //오브젝트의 원래 위치 구하기(다른 곳에다 드랍 했을 때 원래 위치로 귀환)
    private void Start()
    {
        originPos = this.transform.position;
    }

    //대충 어웨이크
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //드래그 시작!
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(dontMove == false)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        else if(dontMove == true)
        {
            Debug.Log("멈춰!");
        }
    }

    //드래그 하는 중...
    public void OnDrag(PointerEventData eventData)
    {
        if(dontMove == false)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        else if(dontMove == true)
        {
            Debug.Log("멈춰!");
        }
    }

    //드래그 끝!
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if(dontMove == false)
        {
            this.transform.position = originPos;
            Debug.Log("넌 못 지나간다");
        }
    }

    //포인터 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //드랍 했을 떄
    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
