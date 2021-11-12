using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMgr : MonoBehaviour
{
    public Fade fade;

    void Start()
    {
        fade = GetComponent<Fade>();
    }

    public void FadeIn()
    {
        StartCoroutine(fade.FadeIn());
    }

    public void StartBtn()
    {
        DataManager.instance.ResetData();
        StartCoroutine(fade.FadeOut(1.0f, "GameScene"));
    }

    public void ReStartBtn()
    {
        DataManager.instance.LoadData();
        StartCoroutine(fade.FadeOut(1.0f, "GameScene"));
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
