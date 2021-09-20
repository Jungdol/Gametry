using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_switch : MonoBehaviour
{

    public Image image;
    public Sprite[] sprite;

    public static int Energy_num = 0;
    public int enerSentNum;

    public void nextEnergy()
    {
        if(Energy_num == 4)
        {
            Energy_num = 0;
            enerSentNum = Energy_num;
            image.sprite = sprite[Energy_num];
        }
        else
        {
            Energy_num += 1;
            enerSentNum = Energy_num;
            image.sprite = sprite[Energy_num];
        }
    }

    public void preEnergy()
    {
        if(Energy_num == 0)
        {
            Energy_num = 4;
            enerSentNum = Energy_num;
            image.sprite = sprite[Energy_num];
        }
        else
        {
            Energy_num -= 1;
            enerSentNum = Energy_num;
            image.sprite = sprite[Energy_num];
        }
    }

}
