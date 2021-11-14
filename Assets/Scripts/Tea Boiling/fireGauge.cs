using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireGauge : MonoBehaviour
{
    public BoliDragNDrop boliDragNDrop;

    public GameObject fireGaugeBar;
    public Image bar;

    public GameObject nowCharcoal;
    public Sprite[] charcoal;

    Image nowCharcoalImage;
    Animator anim;

    GameObject fireGm;
    Animator fireAnim;

    private float gauge = 0;
    private float oneClickGauge = 17;
    private int boilStat = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();

        nowCharcoalImage = nowCharcoal.GetComponent<Image>();
        fireGm = nowCharcoal.transform.GetChild(0).gameObject;
        fireAnim = fireGm.GetComponent<Animator>();
    }

    public void BoilingBtn() // 물이 다 끓었을 때
    {
        anim.SetBool("Appear", true);
    }

    public void BoilingBackBtn()
    {
        anim.SetBool("Appear", false);
        AudioManager.instance.Stop("Fire");
    }

    public void Boiling()
    {
        if(boilStat < 5)
        {
            boilStat += 1;
            fireGaugeBar.SetActive(true);
            gauge += oneClickGauge;
            bar.fillAmount = gauge / 100f;

            nowCharcoalImage.sprite = charcoal[boilStat - 1];
            

            if (boilStat == 5)
            {
                fireGm.SetActive(true);
            }
        }
        else
        {
            bar.fillAmount = 1;
            fireGaugeBar.SetActive(false);
            boliDragNDrop.fireReady = true;
            fireAnim.SetBool("Appear", true);

            Debug.Log("불 준비 완료");
            AudioManager.instance.Play("Fire");
        }
    }
}
