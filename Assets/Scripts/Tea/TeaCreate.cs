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

    Animator finishTeaAnim;

    //제어 변수
    public static int throw_awayChance = 2;


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

    //차 대접하기
    public void TreatTea()
    {
        Debug.Log("차 제조 끝!");
    }

    //결과 출력
    public void FinishTea()
    {
        teafinish.SetActive(true);
        finishTeaAnim = GetComponent<Animator>();

        finishTeaAnim.SetBool("Appear", true);

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
                tea_name.text = "밤바다";
                tea_efficacy.text = "검푸른 물안은 따뜻할까요";
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
                tea_name.text = "별빛";
                tea_efficacy.text = "눈부신 별의 노래를 들어보셨나요";
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
                tea_name.text = "오늘의 하늘";
                tea_efficacy.text = "오늘의 하늘은 어땠나요";
                break;
            case 10:
                tea_name.text = "푸른 밤";
                tea_efficacy.text = "새벽 공기 끝자락의 밤은 어떤 향일까요";
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
                tea_name.text = "가을의 향기";
                tea_efficacy.text = "";
                break;
            case 14:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 15:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 16:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 17:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 18:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 19:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 20:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
            case 21:
                tea_name.text = "";
                tea_efficacy.text = "";
                break;
        }
    }


}
