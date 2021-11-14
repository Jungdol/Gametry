using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance;

    private AudioManager theAudio;
    private List<string> answerList;

    [Header("선택창")]
    public GameObject go; // 평소 비활성화 목적
    public Image goImage;

    [Header("답변 텍스트")]
    public Text[] answer_Text;
    [Header("답변 버튼")]
    public GameObject[] answer_Panel;
    [Header("답변 게임오브젝트")]
    public RectTransform answerGo;

    Animator anim;

    [Header("사운드")]
    public string keySound;
    public string enterSound;

    public bool isChoice; // 선택지 대기

    private int count;

    private int result; // 선택한 선택창

    private float timer = 0;
    Vector2 lerpDir;
    bool isCoroutine;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);
    private float printWaitTime = 0.75f;

    Coroutine moveCoroutine;

    void Start()
    {
        anim = go.GetComponentInChildren<Animator>();
        theAudio = FindObjectOfType<AudioManager>();
        answerList = new List<string>();
        for(int i = 0; i <= 2; i++) // 원래는 answer_Text.Length 로 해야하지만 2개의 선택지도 있기에 3번째가 초기화가 안되므로 3개로 설정
        {
            answer_Text[i].text = "";
            answer_Panel[i].SetActive(false);
        }
    }

    public void ShowChoice(Choice _choice)
    {
        go.SetActive(true);
        isChoice = true;
        result = 0;
        MoveAnswer("Reset");

        for (int i = 0; i < _choice.answers.Length; i++) // 선택지 개수만큼 보이게 하기
        {
            answerList.Add(_choice.answers[i]);
            answer_Panel[i].SetActive(true);
            count = i;
        }

        anim.SetBool("Appear", true);
        StartCoroutine(TypingAnswer_0(0.5f));
        //StartCoroutine(ChoiceCoroutine());
    }

    public void ExitChoice()
    {
        for (int i = 0; i <= count; i++)
        {
            answer_Text[i].text = "";
            answer_Panel[i].SetActive(false);
        }
        theAudio.Play(enterSound);

        isChoice = false;
        answerList.Clear();
        anim.SetBool("Appear", false);
    }

    public int GetResult()
    {
        go.SetActive(false);
        return result;
    }

    IEnumerator ChoiceCoroutine()
    {
        yield return new WaitForSeconds(0.4f);

        StartCoroutine(TypingAnswer_0());
        if (count >= 1)
            StartCoroutine(TypingAnswer_1());
        if (count >= 2)
            StartCoroutine(TypingAnswer_2());

        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator TypingAnswer_0(float _waitTime = 0)
    {
        if (_waitTime == 0) _waitTime = printWaitTime;

        answer_Text[0].text = "";

        yield return new WaitForSeconds(_waitTime);
        for (int i = 0; i < answerList[0].Length; i++)
        {
            answer_Text[0].text += answerList[0][i];
            yield return waitTime;
        }
    }

    IEnumerator TypingAnswer_1()
    {
        answer_Text[1].text = "";

        yield return new WaitForSeconds(printWaitTime);
        for (int i = 0; i < answerList[1].Length; i++)
        {
            answer_Text[1].text += answerList[1][i];
            yield return waitTime;
        }
    }

    IEnumerator TypingAnswer_2()
    {
        answer_Text[2].text = "";

        yield return new WaitForSeconds(printWaitTime);
        for (int i = 0; i < answerList[2].Length; i++)
        {
            answer_Text[2].text += answerList[2][i];
            yield return waitTime;
        }
    }

    IEnumerator MoveAnswer(int _result, string dir)
    {
        if (timer < 1)
            timer += Time.fixedDeltaTime * 1.75f;

        if (_result == 0)
        {
            lerpDir = new Vector2(0f, answerGo.anchoredPosition.y);
            if (dir != "Reset")
            StartCoroutine(TypingAnswer_0());
        }
            
        else if (_result == 1)
        {
            lerpDir = new Vector2(-850f, answerGo.anchoredPosition.y);
            StartCoroutine(TypingAnswer_1());
        }
            
        else if (_result == 2)
        {
            lerpDir = new Vector2(-1700f, answerGo.anchoredPosition.y);
            StartCoroutine(TypingAnswer_2());
        }
            
        while (true)
        {
            answerGo.anchoredPosition = Vector2.Lerp(answerGo.anchoredPosition, lerpDir, timer);

            if (dir == "Right" && answerGo.anchoredPosition.x <= lerpDir.x + 1 ||
                (dir == "Left" || dir == "Reset") && answerGo.anchoredPosition.x >= lerpDir.x - 1)
            {
                isCoroutine = false;
                yield break;
            }
            yield return null;
        }
    }

    void MoveAnswer(string dir)
    {
        isCoroutine = true;
        timer = 0;

        moveCoroutine = StartCoroutine(MoveAnswer(result, dir));
    }

    public void ArrowBtn(string dir)
    {
        if (dir == "Left")
        {
            theAudio.Play(keySound);
            if (result > 0 && !isCoroutine)
            {
                result--;
                MoveAnswer(dir);
            }

            else if (!isCoroutine)
            {
                result = count;
                if (count == 2) answer_Text[1].text = "";
                MoveAnswer("Right");
            }
                
        }
        else if (dir == "Right")
        {
            theAudio.Play(keySound);
            if (result < count && !isCoroutine)
            {
                result++;
                MoveAnswer(dir);
            }
            else if (!isCoroutine)
            {
                result = 0;
                if (count == 2) answer_Text[1].text = "";
                MoveAnswer("Left");
            }
        }
    }
}
