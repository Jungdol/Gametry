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

    [Header("날짜")]
    public GameObject[] aFewDays;

    [HideInInspector]
    public GameObject[] nowDay; // 시간 (아침, 점심, 저녁)

    StageChange stageChange;

    DialogueManager dialogueManager;

    AudioManager audioManager;

    WaitForSeconds waitforSec = new WaitForSeconds(0.375f);

    void Start()
    {
        stageChange = GetComponent<StageChange>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        audioManager = FindObjectOfType<AudioManager>();

        fade = GetComponent<Fade>();
        StartCoroutine(fade.FadeIn());
        DataManager.instance.LoadData();
        GuestSettings();
    }

    private void GuestSettings()
    {
        int _aFewDays = DataManager.instance.a_Few_Days;
        int _nowDay = (int)DataManager.instance.now_Day;

        aFewDays[_aFewDays].SetActive(true);
        nowDay[_nowDay].SetActive(true);

        //for (int i = 0; i < 3; i++)
        //    nowDay[i] = aFewDays[_aFewDays].transform.GetChild(i).gameObject;
        nowDay[_nowDay] = aFewDays[_aFewDays].transform.GetChild(_nowDay).gameObject;
        nowDay[_nowDay].SetActive(true);

        Debug.Log(_aFewDays + " " + _nowDay);
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
        animWindow.SetBool("Appear", false);
        StartCoroutine(SetActiveDelay());
    }

    void AudioStop()
    {
        audioManager.Stop("Red");
        audioManager.Stop("Green");
        audioManager.Stop("Blue");
        audioManager.Stop("Yellow");
        audioManager.Stop("Black");
    }

    public void NextDayBtn()
    {
        AudioStop();
        DataManager.instance.a_Few_Days += 1;
        //DataManager.instance.happy_Index = ;
        DataManager.instance.SaveData();
        LoadingSceneController.LoadScene("GameScene");
    }

    public void ExitDayBtn()
    {
        AudioStop();
        DataManager.instance.a_Few_Days = 0;
        DataManager.instance.a_Few_Days += 1;
        //DataManager.instance.happy_Index = ;

        DataManager.instance.SaveData();
        LoadingSceneController.LoadScene("FinishScene");
    }

    IEnumerator SetActiveDelay()
    {
        yield return waitforSec;
        MakeTeaWindow.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        dialogueManager.TeaDialogue();
    }
}
