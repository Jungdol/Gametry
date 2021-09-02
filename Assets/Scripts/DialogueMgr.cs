﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMgr : MonoBehaviour
{
    public static DialogueMgr instance;
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
    // 대화창 중 이름, 텍스트 출력 변수 선언
    [Header("이름, 대화내용")]
    public Text Name;
    public Text text;

    // 대화창 중 한글자 씩 출력하는 속도, 임시값 저장 변수 선언
    [Header("한글자씩 출력 속도")]
    public float dialogSpeed;
    private float temp = 0;

    // 대화 캐릭터 스프라이트 선언
    [Header("대화할 캐릭터 이미지, 애니메이션")]
    public Image rendererSprite;
    public Animator animSprite;

    // 대화창 이미지 선언
    [Header("대화창 이미지, 애니메이션")]
    public Image rendererDialogueWindow;
    public Animator animDialogueWindow;

    // 대화창 중 대화 내용들, 이름들을 List<Sprite>로 선언
    private List<string> listNames;
    private List<string> listSentences;
    // 1, 2, 3 스프라이트들을 List<Sprite>로 선언
    private List<Sprite> listSprites;

    // 대화창 중 스프라이트를 왼쪽, 오른쪽으로 이동하는 List<bool> 선언
    private List<string> listSpriteState;

    //다이로그 백그라운드 관리하는 List<Sprite> 설정
    private List<Sprite> listDialogueWindows;

    // 대화 진행 상황 카운트 int 선언
    private int count;

    // 말하는 지 안하는 지 체크해주는 bool 선언, 대화하는 동안 키 입력을 금지하는 bool 선언 (RPG에서 대화 시 사용)
    [HideInInspector]
    public bool talking = false;
    private bool keyActivated = false;

    void Start()
    {
        // 초기 실행 시 변수 설정
        count = 0;
        Name.text = "";
        text.text = "";

        listSentences = new List<string>();
        listNames = new List<string>();
        listSprites = new List<Sprite>();

        listSpriteState = new List<string>();

        listDialogueWindows = new List<Sprite>();
        dialogSpeedSave();
    }

    public void ShowDialogue(Dialogue[] dialogue)
    {
        talking = true;
        for (int i = 0; i < dialogue.Length; i++)
        {
            // 다이로그 수 만큼 대화, 사람 인원, 이름, 스프라이트, 왼쪽, 오른쪽 이동 스프라이트, 대화창 설정
            listSentences.Add(dialogue[i].sentences);
            listNames.Add(dialogue[i].names);
            listSprites.Add(dialogue[i].Sprites);
            listSpriteState.Add(dialogue[i].SpriteState);
            listDialogueWindows.Add(dialogue[i].dialogueWindows);
        }
        // 스프라이트 애니메이션 실행
        animSprite.SetBool("Appear", true);
        animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());
    }
    public void Exitdialogue()
    {
        // 다이로그 종료. 모든 변수 초기화
        count = 0;
        Name.text = "";
        text.text = "";
        listNames.Clear();
        listSentences.Clear();
        listSprites.Clear();
        listDialogueWindows.Clear();
        animDialogueWindow.SetBool("Appear", false);
        talking = false;
        ExitSprite();
    }
    void StartSprite()
    {
        // 왼쪽, 오른쪽 스프라이트 이동 bool이 true, false 일 때 스프라이트 이동 bool 설정 -> 현재 미사용
        // 첫번째 스프라이트 왼쪽, 오른쪽 bool이 true 일 때

        /*
        if (listSpriteState[count] == "Left")
            animSprite.SetBool("Left", true);
        else if (listSpriteState[count] == "Right")
            animSprite.SetBool("Right", true);
        else
        {
            animSprite.SetBool("Right", false);
            animSprite.SetBool("Left", false);
        }*/


    }
    void ExitSprite()
    {
        // 모든 애니메이션 종료. 애니메이터 내 bool 초기화
        animSprite.SetBool("Appear", false);
        animSprite.SetBool("Left", false);
        animSprite.SetBool("Right", false);

    }

    public void Next()
    {
        //if (talking && keyActivated)
        {
            // 스페이스 이외 다른 키 입력 X
            keyActivated = false;
            count++;
            text.text = "";
            Name.text = "";
            if (count == listSentences.Count)
            {
                // 대화 수 카운트가 설정한 대화 수일 때 실행
                StopAllCoroutines();
                Exitdialogue();
            }
            else
            {
                // 아닐 시 계속 다이로그 실행
                StopAllCoroutines();
                StartCoroutine(StartDialogueCoroutine());
            }
            /*
            if (Input.GetMouseButtonDown(0))
            {
                dialogSpeed = 0.001f;
            }
            */
        }
    }

    IEnumerator StartDialogueCoroutine()
    {
        Name.text += listNames[count];
        StartSprite();
        dialogSpeedImport();
        // if문 만약 count가 0보다 클 시 실행
        if (count > 0)
        {
            // if문 지금 출력하는 대화창 백그라운드와 전 대화창 백그라운드를 비교하고 다를 시 Appear을 껏다 켜 체인지하는 모션 발생
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])
            {
                // animSprite 부분은 만약 대화창이 이름이 새겨진 대화창일 시 지워줘야 한다.
                //animSprite.SetBool("Change", true);
                // animDialogue 까지 주석 처리하는 부분은 대화창 백그라운드를 바꿀 때 체인지 모션을 사용하지 않기 때문이다. (미연시 때문) 
                //animDialogueWindow.SetBool("Appear", false);
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<Image>().sprite = listDialogueWindows[count];
                //rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
                //animDialogueWindow.SetBool("Appear", true);
                //animSprite.SetBool("Change", false);
            }
            else
            {
                // if문은 다 지금 출력하는 스프라이트와 전 스프라이트를 비교하고 다를 시 Change 함수를 실행, 아닐 시 시간 0.005 딜레이를 줌. 3가지 다 각각의 스프라이트이다
                if (listSprites[count] != listSprites[count - 1])
                {
                    animSprite.SetBool("Change", true);
                    yield return new WaitForSeconds(0.1f);
                    rendererSprite.GetComponent<Image>().sprite = listSprites[count];
                    animSprite.SetBool("Change", false);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
        // count가 0보다 크지 않을 때 리스트 스프라이트에 저장된 스프라이트를 렌더러로 불러옴, 리스트 다이로그 윈도우에 저장된 다이로그를 렌더러로 불러옴
        else
        {
            rendererSprite.GetComponent<Image>().sprite = listSprites[count];
            rendererDialogueWindow.GetComponent<Image>().sprite = listDialogueWindows[count];
        }
        // 키 입력 허용
        keyActivated = true;

        // 한글자씩 출력
        for (int i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i];
            yield return new WaitForSeconds(dialogSpeed);
        }
    }

    // 대화창 출력 속도를 temp에 저장
    void dialogSpeedSave()
    {
        temp = dialogSpeed;
    }

    // 대화창 출력 속도를 temp에서 불러옴
    void dialogSpeedImport()
    {
        dialogSpeed = temp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
