using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaCreate : MonoBehaviour
{

    //스크립트 불러오기
    public TeaSelect teaSelect;
    public IngameMgr ingameMgr;

    [Header("창")]
    public GameObject teafinish;

    [Header("차 이름 / 효능 UI")]
    public Text tea_name;
    public Text tea_efficacy;
    public GameObject des_win;

    [Header("버리기 버튼 / 텍스트")]
    public GameObject throw_awayBtn;
    public Text throw_awayText;

    [Header("차 대접 버튼 / 텍스트")]
    public GameObject treatBtn;

    [Header("컷씬")]
    public Image Bg;
    public GameObject cutscene;
    public Image[] cutSceneImage;

    [Header("차 완성 이미지")]
    public Sprite[] TeaImages;

    [Header("차 적용 이미지")]
    public Image tableTea;
    public Image finishTea;

    Animator finishTeaAnim;

    DialogueManager dialogueManager;

    //제어 변수
    public static int throw_awayChance = 2;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    //차 버리기
    public void ThrowAway()
    {
        if(throw_awayChance > -1)
        {
            throw_awayText.text = "차 버리기 " + "X"+throw_awayChance;
            Debug.Log("차 버릴 수 있는 기회 : " + throw_awayChance);
            throw_awayChance -= 1;
            teafinish.SetActive(false);
            teaSelect.TeaReset();
        }
        else
        {
           Debug.Log("더 이상 차를 버릴 수 없습니다");
        }
    }
    public IEnumerator FadeIn(Image fadeImage, int r = 1, int g = 1,int b = 1)
    {
        float fadeCount = fadeImage.color.a;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(r, g, b, fadeCount);
        }
    }

    IEnumerator cutSceneActive()
    {
        yield return new WaitForSeconds(0.5f);
        cutscene.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(FadeIn(cutSceneImage[0]));
        StartCoroutine(FadeIn(cutSceneImage[1]));
        StartCoroutine(FadeIn(cutSceneImage[2]));
        StartCoroutine(FadeIn(Bg, 0, 0, 0));

        yield return new WaitForSeconds(5f);
        StopCoroutine("cutSceneActive");
    }

    //차 대접하기
    public void TreatTea()
    {
        StartCoroutine("TeaFinish");
    }

    IEnumerator TeaFinish()
    {
        Animator teaBoilingAnim = FindObjectOfType<fireGauge>().gameObject.GetComponent<Animator>();
        teaBoilingAnim.SetBool("Appear", false);
        yield return new WaitForSeconds(0.25f);

        finishTeaAnim = GetComponent<Animator>();
        finishTeaAnim.SetBool("Appear", false);
        yield return new WaitForSeconds(0.25f);

        dialogueManager.TeaFinishDialogue();
        Debug.Log("차 제조 끝!");
        StopCoroutine("TeaFinish");
    }

    //결과 출력
    public void FinishTea()
    {
        teafinish.SetActive(true);
        finishTeaAnim = GetComponent<Animator>();

        finishTeaAnim.SetBool("Appear", true);

        StartCoroutine("cutSceneActive");

        ChangeTeaImage(teaSelect.send_num - 1);

        switch (teaSelect.send_num)
        {
            case 1:
                tea_name.text = "조각 구름";
                tea_efficacy.text = "누가 뜯어먹은 구름일까요";
                break;
            case 2:
                tea_name.text = "은하수";
                tea_efficacy.text = "몽환의 안엔 누가 있을까요";
                break;
            case 3:
                tea_name.text = "꿈";
                tea_efficacy.text = "꿈에 삼켜지고 싶었던 적이 있나요";
                break;
            case 4:
                tea_name.text = "밤하늘";
                tea_efficacy.text = "어두운 밤에 기대어 쉬고 싶었던 적이 있나요";
                break;
            case 5:
                tea_name.text = "달빛";
                tea_efficacy.text = "달빛의 향은 무엇일까요";
                break;
            case 6:
                tea_name.text = "금빛 하루";
                tea_efficacy.text = "완벽한 하루는 어떤 하루일까요";
                break;
            case 7:
                tea_name.text = "노을";
                tea_efficacy.text = "지는 해의 감정은 어떨까요";
                break;
            case 8:
                tea_name.text = "숲의 향연";
                tea_efficacy.text = "초록빛 향으로 가득한 차예요";
                break;
            case 9:
                tea_name.text = "하늘";
                tea_efficacy.text = "오늘의 하늘은 어땠나요";
                break;
            case 10:
                tea_name.text = "푸른 새벽";
                tea_efficacy.text = "새벽녘의 차가움을 느껴보셨나요";
                break;
            case 11:
                tea_name.text = "파도";
                tea_efficacy.text = "파도에 휩쓸려 버린다면 마음이 좀 편할까요";
                break;
            case 12:
                tea_name.text = "눈꽃";
                tea_efficacy.text = "시린 겨울에도 나무를 덮어주는 이는 있답니다";
                break;
            case 13:
                tea_name.text = "안개";
                tea_efficacy.text = "은빛으로 잠긴 세상은 어떤가요";
                break;
            case 14:
                tea_name.text = "연못";
                tea_efficacy.text = "연못에 발을 담가 흔적을 남겨보아요";
                break;
            case 15:
                tea_name.text = "오로라";
                tea_efficacy.text = "행복에 색이 있다면 무슨 색일까요";
                break;
            case 16:
                tea_name.text = "잠수";
                tea_efficacy.text = "모든 게 물 속에 잠긴다면 다 괜찮을까요";
                break;
            case 17:
                tea_name.text = "낙엽";
                tea_efficacy.text = "둘의 이별은 아름다울까요";
                break;
            case 18:
                tea_name.text = "봄꽃";
                tea_efficacy.text = "두근거림은 어디서 온 선물일까요";
                break;
            case 19:
                tea_name.text = "겨울";
                tea_efficacy.text = "겨울의 따스함은 어디서 올까요";
                break;
            case 20:
                tea_name.text = "해야";
                tea_efficacy.text = "태양이 녹아내린다면 어떤 모습일까요";
                break;
            case 21:
                tea_name.text = "어스름";
                tea_efficacy.text = "낮과 밤의 사이는 누가 가른 걸까요";
                break;
        }

        void ChangeTeaImage(int num)
        {
            tableTea.gameObject.SetActive(true);
            tableTea.sprite = TeaImages[num];
            finishTea.sprite = TeaImages[num];
        }
    }
}
