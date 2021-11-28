using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    [Header("행복지수 이미지")]
    public Image happyBar;

    [Header("행복지수 빛")]
    public GameObject happyLight;

    [Header("스테이지, 테이블 UI")]
    public SpriteRenderer stageBackground;
    public Image table;

    [Header("스테이지, 테이블 이미지")]
    public Sprite[] stages;
    public Sprite[] tables;

    [Header("배경화면 스프라이트")]
    public  SpriteRenderer background;

    [HideInInspector]
    public GameManager gameManager;

    UIResolution uiResolution;

    [HideInInspector]
    public int nowDay;

    void Start()
    {
        //nowDay = (int)DataManager.instance.now_Day;
        stageBackground.sprite = stages[nowDay];
        table.sprite = tables[nowDay];

        gameManager = FindObjectOfType<GameManager>();
        uiResolution = FindObjectOfType<UIResolution>();

        if (uiResolution.SetUiRatio(true) == 1080)
        {
            Debug.Log("작동");
            background.size = new Vector2(1.1f, 1.1f);
        }
        else
        {
            Debug.Log("작동");
            background.transform.localScale = new Vector2(1.5f, 1.5f);
        }
    }

    void Update()
    {
        happyBar.fillAmount = (float)gameManager.happyIndex / (float)gameManager.happyMax;
    }

    public void HappyIndexPlus(int _value)
    {
        GameManager.instance.happyIndex += _value;
        StartCoroutine("HappyLight");
    }

    IEnumerator HappyLight()
    {
        happyLight.SetActive(true);
        yield return new WaitForSeconds(1f);
        happyLight.SetActive(false);
    }
}
