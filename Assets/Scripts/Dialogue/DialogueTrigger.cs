using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    public Dialogue[] dialogue;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.dialogue = dialogue;
        system.ShowDialogue();
    }
}

