using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMgr : MonoBehaviour
{
    public Fade fade;

    void Start()
    {
        fade = GetComponent<Fade>();
        AudioManager.instance.Play("Title");
    }

    public void FadeIn()
    {
        StartCoroutine(fade.FadeIn());
    }

    public void StartBtn()
    {
        AudioManager.instance.Stop("Title");
        DataManager.instance.ResetData();
        StartCoroutine(fade.FadeOut(1.0f, "CutScene"));
    }

    public void ReStartBtn()
    {
        AudioManager.instance.Stop("Title");
        DataManager.instance.LoadData();
        StartCoroutine(fade.FadeOut(1.0f, "GameScene"));
    }

    public void ExitBtn()
    {
        AudioManager.instance.Stop("Title");
        Application.Quit();
    }
}
