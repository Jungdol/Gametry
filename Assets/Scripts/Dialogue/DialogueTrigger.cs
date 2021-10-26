using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("맨 처음 등장할 때")]
    public Sprite firstSprite;

    DialogueManager dialogueManager;

    [SerializeField]
    public Dialogue[] dialogue;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.dialogue = dialogue;
        system.ShowDialogue();
    }
    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.rendererImage.sprite = firstSprite;
    }
}

