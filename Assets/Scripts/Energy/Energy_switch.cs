using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_switch : MonoBehaviour
{

    public Image image;
    public Sprite[] sprite;

    public static int Energy_num = 0;

    public void nextEnergy()
    {
        if(Energy_num == 4)
        {
            Energy_num = 0;
            image.sprite = sprite[Energy_num];
        }
        else
        {
            Energy_num += 1;
            image.sprite = sprite[Energy_num];
        }
    }

    public void preEnergy()
    {
        if(Energy_num == 0)
        {
            Energy_num = 4;
            image.sprite = sprite[Energy_num];
        }
        else
        {
            Energy_num -= 1;
            image.sprite = sprite[Energy_num];
        }
    }

}
