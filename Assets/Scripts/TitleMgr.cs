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
        StartCoroutine(fade.FadeOut("GameScene"));
    }
}
