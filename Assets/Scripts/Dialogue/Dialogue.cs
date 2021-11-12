using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Dialogue
{
    public string names;
    [TextArea]
    public string sentences;

    public Sprite Sprites;

    public string SpriteState;

    public Sprite dialogueWindows;
    public ChoiceContent choiceContents;
    public bool makeTea;
    public bool energy;
    public bool finishTea;
    public bool choiceTea;

    public Energy characterEnergy;

    public DialogueTrigger nextDialogues;
}

[System.Serializable]
public class DialogueEvent
{
    public string name;

    public Vector2 line;
    public Dialogue[] dialogues;
}