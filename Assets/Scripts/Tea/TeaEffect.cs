using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaEffect : MonoBehaviour
{
    public Sprite[] effectSprite;
    public DialogueTrigger[] teaFinishDialogue;
    public GameObject[] teaEffect;
    DataManager dataManager;
    int num = 0;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
        Debug.Log(dataManager.a_Few_Days);

        switch (dataManager.a_Few_Days)
        {
            case 0:
                num = 0; // 오전: 0, 1, 2
                break;

            case 1:
                num = 3; // 오후: 3, 4, 5
                break;

            case 2:
                num = 6; // 저녁: 6, 7, 8
                break;
        }
        
        switch (dataManager.now_Day)
        {
            case day.morning:
                num += 0;
                break;

            case day.afternoon:
                num += 1;
                break;

            case day.evening:
                num += 2;
                break;
        }

        Debug.Log(num);
        for (int i=0; i < 2; i++)
        {
            Debug.Log((int)teaFinishDialogue[num].teaFinishNum[i]);
            Image image = teaEffect[(int)teaFinishDialogue[num].teaFinishNum[i]].GetComponent<Image>();
            image.sprite = effectSprite[(int)Random.Range(0f, 4f)];
            image.gameObject.GetComponent<Animator>().SetBool("Appear", true);
        }
        
    }
}
