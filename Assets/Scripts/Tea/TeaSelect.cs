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

    public static int chance = 0;
    public static bool stoping = true;

    public GameObject resetBtn;
    public GameObject makeTeaBtn;


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
                Debug.Log(teaStatus1.name);
            }
            //두번째 선택
            else if(chance == 1)
            {
                Debug.Log("2번째 선택");
                teaStatus2 = new TeaStatus();
                teaStatus2 = teaStatus2.SetTeaStatus(teaMaterial);
                Debug.Log(teaStatus2.name);

                //만약 똑같은 재료 클릭시 무효처리
                if(teaStatus1.name == teaStatus2.name)
                {
                    Debug.Log("이미 선택한 재료입니다"); 
                    teaStatus2 = null;
                }
                //다른 재료 클릭시 값을 저장하고 버튼을 띄움
                else if(teaStatus1.name != teaStatus2.name)
                {
                    Debug.Log("차를 제작할 수 있습니다");
                    Debug.Log("재료1 : "+ teaStatus1.name+" 재료2 : "+teaStatus2.name);

                    resetBtn.SetActive(true);
                    makeTeaBtn.SetActive(true);

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
        teaStatus1 = null;
        teaStatus2 = null;
        resetBtn.SetActive(false);
        makeTeaBtn.SetActive(false);

        Debug.Log("리셋!");
        Debug.Log("재료1 :"+ teaStatus1.name+" 재료2 :"+teaStatus2.name);

    }

}
