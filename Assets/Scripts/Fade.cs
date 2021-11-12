using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public GameObject fade;
    public Image fadeImage;

    GameObject tempFade;
    Image tempFadeImage;

    public bool fadeSetActive = false;

    public float waitTime = 0f;

    void Start()
    {
        fade.SetActive(fadeSetActive);
        tempFade = fade;
        tempFadeImage = fadeImage;
    }

    public void FadeReset()
    {
        fade = tempFade;
        fadeImage = tempFadeImage;
    }

    public IEnumerator FadeIn(float fadeCountMax = 0.0f)
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(waitTime);

        float fadeCount = fadeImage.color.a;
        while (fadeCount > fadeCountMax)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeCount);
        }
        fade.SetActive(false);
    }

    public IEnumerator FadeOut(float fadeCountMax = 1.0f, string _scene = "")
    {
        fade.SetActive(true);

        float fadeCount = 0;
        while (fadeCount < fadeCountMax)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeCount);
        }
        if (_scene != "")
            LoadingSceneController.LoadScene(_scene);
    }
}
