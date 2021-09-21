using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMgr : MonoBehaviour
{
    //스크립트 불러오기
    public Energy_switch energy1;
    public Energy_switch energy2;

    public GameObject energy_ex;

    public void ShowEx()
    {
        energy_ex.SetActive(true);
    }

    public void cleanUpEx()
    {
        energy_ex.SetActive(false);
    }

    //기 출력하기
    public void changeMood()
    {
        switch(Energy_switch.Energy_num)
        {
            case 0:
                Debug.Log("노랑!");
                break;
            case 1:
                Debug.Log("파랑!");
                break;
            case 2:
                Debug.Log("빨강!");
                break;
            case 3:
                Debug.Log("초록!");
                break;
            case 4:
                Debug.Log("검정!");
                break;
        }
    }
}
