using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireGauge : MonoBehaviour
{
    public BoliDragNDrop boliDragNDrop;

    public GameObject fireGaugeBar;
    public Image bar;

    private float gauge = 0;
    private float oneClickGauge = 17;
    private int boilStat = 1;


    public void Boiling()
    {
        if(boilStat < 6)
        {
            boilStat += 1;
            fireGaugeBar.SetActive(true);
            gauge += oneClickGauge;
            bar.fillAmount = gauge / 100f;
        }
        else
        {
            bar.fillAmount = 1;
            fireGaugeBar.SetActive(false);
            boliDragNDrop.fireReady = true;
            Debug.Log("불 준비 완료");
        }
    }
}
