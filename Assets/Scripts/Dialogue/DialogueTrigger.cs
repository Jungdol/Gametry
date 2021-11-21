using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("맨 처음 등장할 때")]
    public Sprite firstSprite;

    [Header("차 마시는 이미지")]
    public Sprite tasteTeaSprite;

    [HideInInspector]
    public DialogueManager dialogueManager;

    [SerializeField]
    public Dialogue[] dialogue;
    public DialogueTrigger[] energyDialogues;
    [Header("차 좋음, 보통, 별로")] 
    public int[] teaFinishNum;
    public DialogueTrigger[] teaFinishDialogues;

    TeaCreate teaCreate;
    StageChange stageChange;

    private void Start()
    {
        teaCreate = FindObjectOfType<TeaCreate>();
        stageChange = FindObjectOfType<StageChange>();
    }
    public void OnTrigger() // 버튼 전용
    {
        Trigger();
    }

    public void TeaChoiceDialogue()
    {
        for (int i = 0; i < teaFinishNum.Length; i++)
        {
            if (teaCreate.teaSelect.send_num == teaFinishNum[i])
            {
                teaFinishDialogues[i].Trigger();
                TeaHappyIndex(i);
            }
        }
    }

    void TeaHappyIndex(int i)
    {
        switch (teaFinishNum[i])
        {
            case 0:
                stageChange.HappyIndexPlus(20);
                break;
            case 1:
                stageChange.HappyIndexPlus(10);
                break;
            case 2:
                stageChange.HappyIndexPlus(-10);
                break;
        }
    }

    public void ImageSetting()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.rendererImage.sprite = firstSprite;
    }

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.dialogue = dialogue;
        system.dialogueTrigger = this;
        system.ShowDialogue();
    }
}

