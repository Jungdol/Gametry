﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMgr : MonoBehaviour
{
    public Fade fade;

    void Start()
    {
        fade = GetComponent<Fade>();
        StartCoroutine(fade.FadeIn());
    }

    public void FadeIn()
    {
        StartCoroutine(fade.FadeIn());
    }

    public void SceneChange()
    {
        LoadingSceneController.LoadScene("end");
    }
}
