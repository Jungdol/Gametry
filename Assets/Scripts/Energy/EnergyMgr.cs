using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Energy
{
    Red,
    Green,
    Blue,
    Yellow,
    Black
}

public class EnergyMgr : MonoBehaviour
{
    //스크립트 불러오기
    public Energy_switch energy1;
    public Energy_switch energy2;

    public GameObject energy_ex;

    public Energy nowEnergy;
    public Energy characterEnergy = Energy.Yellow;

    public GameObject makeTeaBtn;
    public GameObject energyBg;

    public bool onClick = false;

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
                nowEnergy = Energy.Red;
                Debug.Log("빨강!");
                break;
                
            case 1:
                nowEnergy = Energy.Green;
                Debug.Log("초록!");
                break;
                
            case 2:
                nowEnergy = Energy.Blue;
                Debug.Log("파랑!");
                break;
            case 3:
                nowEnergy = Energy.Yellow;
                Debug.Log("노랑!");
                break;
            case 4:
                nowEnergy = Energy.Black;
                Debug.Log("검정!");
                break;
        }
        makeTeaBtn.SetActive(false);
        energyBg.SetActive(false);
    }

    public int EnergySetting()
    {
        if (nowEnergy == characterEnergy)
        {
            StageChange.instance.happyIndex += 20;
            return 0;
        }
        else
            return 1;
    }
}
