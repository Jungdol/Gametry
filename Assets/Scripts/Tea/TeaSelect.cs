using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TeaSelect : MonoBehaviour
{
    public static TeaStatus teaStatus1;
    public static TeaStatus teaStatus2;
    public TeaMaterial teaMaterial;

    private TeaCreate teaCreate;

    static int chance = 0;
    static bool stoping = true;

    public GameObject teaSelectwindow;

    [Header("버튼 UI")]
    public GameObject resetBtn;
    public GameObject makeTeaBtn;


    [Header("차 재료 설명 UI")]
    public Text TeaIngName;
    public Text TeaDes;
    public GameObject TeaDes_Window;


    public static int tea_number = 0;
    public int send_num;

    bool isTwoCases(TeaMaterial _teaMaterial1, TeaMaterial _teaMaterial2)
    {
        if (teaStatus1.teaMaterial == _teaMaterial1 && teaStatus2.teaMaterial == _teaMaterial2 || teaStatus1.teaMaterial == _teaMaterial2 && teaStatus2.teaMaterial == _teaMaterial1)
            return true;
        else
            return false;
    }

    //차 재료 선택 함수
    public void TeaSelects()
    {
        if(stoping)
        {
            //첫번째 선택
            if(chance == 0)
            {
                Debug.Log("1번째 선택");
                chance = 1;
                teaStatus1 = new TeaStatus();
                teaStatus1 = teaStatus1.SetTeaStatus(teaMaterial);

                TeaDes_Window.SetActive(true);

                TeaIngName.text = teaStatus1.name;
                TeaDes.text = teaStatus1.efficacy;

                Debug.Log(teaStatus1.name);
            }
            //두번째 선택
            else if(chance == 1)
            {
                Debug.Log("2번째 선택");
                teaStatus2 = new TeaStatus();
                teaStatus2 = teaStatus2.SetTeaStatus(teaMaterial);

                TeaIngName.text = teaStatus2.name;
                TeaDes.text = teaStatus2.efficacy;

                Debug.Log(teaStatus2.teaMaterial);

                //만약 똑같은 재료 클릭시 무효처리
                if(teaStatus1.teaMaterial == teaStatus2.teaMaterial)
                {
                    Debug.Log("이미 선택한 재료입니다"); 
                    teaStatus2 = null;
                }
                //다른 재료 클릭시 값을 저장하고 버튼을 띄움
                else if(teaStatus1.name != teaStatus2.name)
                {
                    Debug.Log("차를 제작할 수 있습니다");
                    Debug.Log("재료1 : "+ teaStatus1.teaMaterial+" 재료2 : "+teaStatus2.teaMaterial);

                    resetBtn.SetActive(true);
                    makeTeaBtn.SetActive(true);

                    if(isTwoCases(TeaMaterial.A, TeaMaterial.B))
                    {
                        tea_number = 1;
                    }
                    else if(isTwoCases(TeaMaterial.A, TeaMaterial.C))
                    {
                        tea_number = 2;
                    }
                    else if(isTwoCases(TeaMaterial.A, TeaMaterial.D))
                    {
                        tea_number = 3;
                    }
                    else if(isTwoCases(TeaMaterial.A, TeaMaterial.E))
                    {
                        tea_number = 4;
                    }
                    else if(isTwoCases(TeaMaterial.A, TeaMaterial.F))
                    {
                        tea_number = 5;
                    }
                    else if(isTwoCases(TeaMaterial.A, TeaMaterial.G))
                    {
                        tea_number = 6;
                    }

                    else if(isTwoCases(TeaMaterial.B, TeaMaterial.C))
                    {
                        tea_number = 7;
                    }
                    else if(isTwoCases(TeaMaterial.B, TeaMaterial.D))
                    {
                        tea_number = 8;
                    }
                    else if(isTwoCases(TeaMaterial.B, TeaMaterial.E))
                    {
                        tea_number = 9;
                    }
                    else if(isTwoCases(TeaMaterial.B, TeaMaterial.F))
                    {
                        tea_number = 10;
                    }
                    else if(isTwoCases(TeaMaterial.B, TeaMaterial.G))
                    {
                        tea_number = 11;
                    }
                    
                    else if(isTwoCases(TeaMaterial.C, TeaMaterial.D))
                    {
                        tea_number = 12;
                    }
                    else if(isTwoCases(TeaMaterial.C, TeaMaterial.E))
                    {
                        tea_number = 13;
                    }
                    else if(isTwoCases(TeaMaterial.C, TeaMaterial.F))
                    {
                        tea_number = 14;
                    }
                    else if(isTwoCases(TeaMaterial.C, TeaMaterial.G))
                    {
                        tea_number = 15;
                    }

                    else if(isTwoCases(TeaMaterial.D, TeaMaterial.E))
                    {
                        tea_number = 16;
                    }
                    else if(isTwoCases(TeaMaterial.D, TeaMaterial.F))
                    {
                        tea_number = 17;
                    }
                    else if(isTwoCases(TeaMaterial.D, TeaMaterial.G))
                    {
                        tea_number = 18;
                    }

                    else if(isTwoCases(TeaMaterial.E, TeaMaterial.F))
                    {
                        tea_number = 19;
                    }
                    else if(isTwoCases(TeaMaterial.E, TeaMaterial.G))
                    {
                        tea_number = 20;
                    }
                    
                    else if(isTwoCases(TeaMaterial.G, TeaMaterial.F))
                    {
                        tea_number = 21;
                    }

                    Debug.Log(tea_number);

                    stoping = false;
                }
            }
        }
        //재료를 모두 선택했다면 버튼을 눌러도 입력이 안되게 하기
        else if(!stoping)
        {
            Debug.Log("더이상 선택할 수 없습니다.");
        }
    }
    //선택한 모든 재료를 리셋하기
    public void TeaReset()
    {
        chance = 0;
        stoping = true;
        TeaDes_Window.SetActive(false);

        teaStatus1 = null;
        teaStatus2 = null;

        resetBtn.SetActive(false);
        makeTeaBtn.SetActive(false);



        Debug.Log("리셋!");
        Debug.Log("재료1 :"+ teaStatus1.name+" 재료2 :"+teaStatus2.name); //출력할 때 오류가 난다면 초기화가 정상 작동 한 것
    }

    public void TeaMake()
    {
        Debug.Log(tea_number);
        send_num = tea_number;
        teaSelectwindow.SetActive(false);

        teaCreate.FinishTea();
    }
}
