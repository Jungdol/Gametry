using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_select : MonoBehaviour
{
    public Energy_switch energy1;
    public Energy_switch energy2;

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
