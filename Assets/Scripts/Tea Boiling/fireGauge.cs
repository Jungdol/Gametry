using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireGauge : MonoBehaviour
{
    public GameObject fireGaugeBar;
    public Image bar;
    public GameObject backBtn;

    private float gauge = 0;
    private float oneClickGauge = 17;
    private int boilStat = 1;


    public void Boiling()
    {
        if(boilStat < 6)
        {
            Debug.Log(boilStat);
            boilStat += 1;
            fireGaugeBar.SetActive(true);
            gauge += oneClickGauge;
            bar.fillAmount = gauge / 100f;
        }
        else
        {
            bar.fillAmount = 1;
            fireGaugeBar.SetActive(false);
            Debug.Log("불 준비 완료");
        }
    }
}
