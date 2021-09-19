using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaCreate : MonoBehaviour
{
    private TeaSelect teaSelect;


    public GameObject teafinish;
    public Text tea_name;
    public GameObject des_win;
    public GameObject throw_awayBtn;
    public GameObject treatBtn;

    public void FinishTea()
    {
        teafinish.SetActive(true);

        switch(teaSelect.send_num)
        {
            case 1:
                tea_name.text = "A+B";
                break;
        }
    }
}
