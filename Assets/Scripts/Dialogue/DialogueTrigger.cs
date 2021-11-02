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

    public void OnTrigger() // 버튼 전용
    {
        Trigger();
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

