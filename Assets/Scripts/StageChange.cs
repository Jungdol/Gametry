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

    public GameManager gameManager;

    [HideInInspector]
    public int nowDay;

    void Start()
    {
        //nowDay = (int)DataManager.instance.now_Day;
        stageBackground.sprite = stages[nowDay];
        table.sprite = tables[nowDay];

        gameManager = FindObjectOfType<GameManager>();
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
