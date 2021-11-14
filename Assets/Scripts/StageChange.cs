using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    public static StageChange instance;
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            NewMethod();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        void NewMethod()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion Singleton

    [Header("행복지수 이미지")]
    public Image happyBar;

    [Header("스테이지, 테이블 UI")]
    public SpriteRenderer stageBackground;
    public Image table;

    [Header("스테이지, 테이블 이미지")]
    public Sprite[] stages;
    public Sprite[] tables;

    [Header("나무 UI")]
    public Image tree;

    [Header("나무 이미지")]
    public Sprite[] treeSprites;

    public float happyIndex = 0;

    float happyMax = 100;
    int treeLevel;

    [HideInInspector]
    public int nowDay;

    private void Start()
    {
        nowDay = (int)DataManager.instance.now_Day;
        stageBackground.sprite = stages[nowDay];
        table.sprite = tables[nowDay];

        happyIndex = DataManager.instance.happy_Index;
        treeLevel = DataManager.instance.tree_Level;
    }
    // Update is called once per frame
    void Update()
    {
        happyBar.fillAmount = happyIndex / happyMax;

        if (happyIndex >= 100)
        {
            treeLevel++;
            tree.sprite = treeSprites[treeLevel];

            happyIndex = 0;
        }
    }
}
