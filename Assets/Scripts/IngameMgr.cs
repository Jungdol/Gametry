using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMgr : MonoBehaviour
{
    [Header("페이드")]
    public Fade fade;

    [Header("각 씬")]
    public GameObject MakeTeaWindow;
    public GameObject Conversation;

    [Header("애니메이션")]
    public Animator animWindow;

    WaitForSeconds waitforSec = new WaitForSeconds(0.5f);

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

    public void ShowTeaScene()
    {
        MakeTeaWindow.SetActive(true);
        animWindow.SetBool("Appear" ,true);
    }

    public void ExitTeaScene()
    {
        MakeTeaWindow.SetActive(false);
        animWindow.SetBool("Appear" ,false);

    }

    IEnumerator delay()
    {
        yield return waitforSec;
    }
}
