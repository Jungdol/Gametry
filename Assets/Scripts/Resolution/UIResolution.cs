using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResolution : MonoBehaviour
{
    public RectTransform uiSize;
    public string Scene;

    [HideInInspector]
    public bool is3_4;

    CanvasScaler canvasScaler;
    Camera mainCamera;

    int x, y;

    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        mainCamera = FindObjectOfType<Camera>();

        SetUiRatio();
    }

    public int SetUiRatio(bool isreturn = false)
    {
        float screenMiddleValue = ((9f / 16f) + (3f / 4f)) / 2f; // 9:16 3:4 중간값 -> 3:4가 9:16보다 값이 큼
        float screenRatio = (float)Screen.width / Screen.height; // (가로 / 세로)
        if(Scene == "Finish")
        {
            SetUiSizeDelta(1440, 1920);
            canvasScaler.matchWidthOrHeight = 0f;
            SetCameraRatio();

            is3_4 = true;
        }
        else
        {
            if (screenRatio > screenMiddleValue) // 중간값보다 큼(3:4 비율)
            {
                x = 1440; y = 1920;
                SetUiSizeDelta(x, y);
                canvasScaler.matchWidthOrHeight = 1f;

                is3_4 = true;
            }
            else if (screenRatio < screenMiddleValue) // 중간값보다 작음(9:16 비율)
            {
                x = 1080; y = 1920;
                SetUiSizeDelta(x, y);
                canvasScaler.matchWidthOrHeight = 0f;
                SetCameraRatio();

                is3_4 = false;
            }
            else // 태블릿 이외 보통폰은 9:16 언저리니.. 보통은 쓰일 일 없음
            {
                x = 1080; y = 1920;
                SetUiSizeDelta(x, y);
                canvasScaler.matchWidthOrHeight = 0f;
                SetCameraRatio();

                is3_4 = false;
            }
        }

        void SetUiSizeDelta(int x, int y)
        {
            uiSize.sizeDelta = new Vector2(x, y);
        }

        if (isreturn)
            return x;

        return 0;
    }

    void SetCameraRatio()
    {
        Rect rect = mainCamera.rect;
        float scaleheight;

        if(Scene == "Finish")
            scaleheight = ((float)Screen.width / Screen.height) / ((float)3 / 4);
        else
            scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);

        rect.height = scaleheight;
        rect.y = (1f - scaleheight) / 2;

        mainCamera.rect = rect;
        Debug.Log(scaleheight);

        void OnPreCull() => GL.Clear(true, true, Color.black);  
    }
}
