using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TeaSelect : MonoBehaviour
{
    public TeaStatus teaStatus1;
    public TeaStatus teaStatus2;
    public TeaMaterial teaMaterial;

    int chance = 0;

    public void TeaSelects()
    {
        if(chance == 0)
        {
            chance += 1;
            teaStatus1 = new TeaStatus();
            teaStatus1 = teaStatus1.SetTeaStatus(teaMaterial);
            Debug.Log(teaStatus1.name);
        }
        else if(chance == 1)
        {
            Debug.Log("2로 넘어감");
            teaStatus2 = new TeaStatus();
            if(teaStatus1 != teaStatus2)
            {
                chance += 1;
                teaStatus2 = teaStatus2.SetTeaStatus(teaMaterial);
                Debug.Log(teaStatus2.name);
            }
            else if(teaStatus1 == teaStatus2)
            {
                Debug.Log("이미 선택한 재료입니다");
            }

        }
        else if(chance == 2)
        {
            Debug.Log("더이상 선택할 수 없습니다.");
        }

    }

}
