using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_switch : MonoBehaviour
{

    public Image image;
    public Sprite[] sprite;

    public static int Energy_num = 0;

    AudioManager audioManager;

    bool isStart = false;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
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

    private void Update()
    {
        if (this.gameObject.activeSelf && !isStart)
        {
            audioManager.Play("Red");
            isStart = true;
        }  
    }

    public void EnergyBgm()
    {
        switch(Energy_num)
        {
            case 0:
                audioManager.Stop("Green"); // 그 전의 기 소리 멈춤
                audioManager.Stop("Black"); // 다음 기 소리 멈춤
                audioManager.Play("Red");
                break;
            case 1:
                audioManager.Stop("Blue"); // 그 전의 기 소리 멈춤
                audioManager.Stop("Red"); // 다음 기 소리 멈춤
                audioManager.Play("Green");
                break;
            case 2:
                audioManager.Stop("Yellow"); // 그 전의 기 소리 멈춤
                audioManager.Stop("Green"); // 다음 기 소리 멈춤
                audioManager.Play("Blue");
                break;
            case 3:
                audioManager.Stop("Black"); // 그 전의 기 소리 멈춤
                audioManager.Stop("Blue"); // 다음 기 소리 멈춤
                audioManager.Play("Yellow");
                break;
            case 4:
                audioManager.Stop("Red"); // 그 전의 기 소리 멈춤
                audioManager.Stop("Yellow"); // 다음 기 소리 멈춤
                audioManager.Play("Black");
                break;

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
