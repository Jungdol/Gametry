using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    public float happyIndex = 0;
    float happyMax = 100;
    public Image happyBar;
    public Image stageBackground;
    public Sprite[] stages;
    int stage = 0;

    public void Trigger()
    {
        happyIndex += 10;
    }
    // Update is called once per frame
    void Update()
    {
        happyBar.fillAmount = happyIndex / happyMax;

        if (happyIndex >= 100)
        {
            stageBackground.sprite = stages[stage];
            stage++;
            happyIndex = 0;
        }
    }
}
