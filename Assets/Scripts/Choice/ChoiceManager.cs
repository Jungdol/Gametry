using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance;
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            NewMethod();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        void NewMethod()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion Singleton

    private AudioManager theAudio;
    private List<string> answerList;

    [Header("선택창")]
    public GameObject go; // 평소 비활성화 목적
    public Image goImage;

    [Header("선택창 이미지")]
    public Sprite Choice1Image;
    public Sprite Choice2Image;

    [Header("답변 텍스트")]
    public Text[] answer_Text;
    [Header("답변 버튼")]
    public GameObject[] answer_Panel;
    [Header("답변 게임오브젝트")]
    public GameObject answerGo;

    Animator anim;

    [Header("사운드")]
    public string keySound;
    public string enterSound;

    public bool isChoice; // 선택지 대기

    private int count;

    private int result; // 선택한 선택창

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {
        anim = answerGo.GetComponentInParent<Animator>();
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
        for (int i = 0; i < _choice.answers.Length; i++) // 선택지 개수만큼 보이게 하기
        {
            answerList.Add(_choice.answers[i]);
            answer_Panel[i].SetActive(true);
            count = i;
        }

        if (_choice.answers.Length == 2)
            goImage.sprite = Choice1Image;
        else
            goImage.sprite = Choice2Image;

        anim.SetBool("Appear", true);
        StartCoroutine(ChoiceCoroutine());
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

    public void Selection(int _result)
    {
        result = _result;
        ExitChoice();
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

    IEnumerator TypingAnswer_0()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < answerList[0].Length; i++)
        {
            answer_Text[0].text += answerList[0][i];
            yield return waitTime;
        }
    }

    IEnumerator TypingAnswer_1()
    {
        yield return new WaitForSeconds(0.9f);
        for (int i = 0; i < answerList[1].Length; i++)
        {
            answer_Text[1].text += answerList[1][i];
            yield return waitTime;
        }
    }

    IEnumerator TypingAnswer_2()
    {
        yield return new WaitForSeconds(1.3f);
        for (int i = 0; i < answerList[2].Length; i++)
        {
            answer_Text[2].text += answerList[2][i];
            yield return waitTime;
        }
    }

    IEnumerator MoveAnswer(string dir)
    {
        float timer = 0;
        if (timer <= 1)
            timer += Time.deltaTime;
        yield return null;
    }

    public void ArrowBtn(string dir)
    {
        if (dir == "Left")
        {
            theAudio.Play(keySound);
            if (result > 0)
            {
                result--;
            }
                
            else
                result = count;
        }
        else if (dir == "Right")
        {
            if (result < 0)
            {
                result++;
            }
            else
                result = count;
        }
    }
}
