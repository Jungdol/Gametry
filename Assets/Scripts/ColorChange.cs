using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public GameObject etcObj;
    public Image ColorBtnImage;
    bool isPressR = false;
    bool isPressG = false;
    bool isPressB = false;

    public void EtcBtnOnclick()
    {
        etcObj.SetActive(!etcObj.activeSelf);
    }
    public void PressR()
    {
        isPressR = true;
        PressCheck();
    }
    public void PressG()
    {
        isPressG = true;
        PressCheck();
    }
    public void PressB()
    {
        isPressB = true;
        PressCheck();
    }
    void PressCheck()
    {

        if (isPressR && isPressG && isPressB)
        {
            isPressR = false;
            isPressG = false;
            isPressB = false;
            ColorBtnImage.color = Color.white;
        }
        else if (isPressR && isPressG)
        {
            ColorBtnImage.color = Color.yellow;
        }
        else if (isPressR && isPressB)
        {
            ColorBtnImage.color = Color.magenta;
        }
        else if (isPressG && isPressB)
        {
            ColorBtnImage.color = Color.cyan;
        }
        else if (isPressR)
        {
            ColorBtnImage.color = Color.red;
        }
        else if (isPressG)
        {
            ColorBtnImage.color = Color.green;
        }
        else if (isPressB)
        {
            ColorBtnImage.color = Color.blue;
        }
    }
}
