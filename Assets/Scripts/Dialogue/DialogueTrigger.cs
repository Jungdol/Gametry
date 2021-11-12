using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("맨 처음 등장할 때")]
    public Sprite firstSprite;

    [HideInInspector]
    public DialogueManager dialogueManager;

    [SerializeField]
    public Dialogue[] dialogue;
    public DialogueTrigger[] energyDialogues;
    [Header("차 좋음, 보통, 별로")] 
    public int[] teaFinishNum;
    public DialogueTrigger[] teaFinishDialogues;

    TeaCreate teaCreate;

    private void Start()
    {
        teaCreate = FindObjectOfType<TeaCreate>().GetComponent<TeaCreate>();
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
                teaFinishDialogues[i].Trigger();
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

