using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Dialogue
{
    public string names;
    public string[] sentences;

    public Sprite Sprites;

    public string SpriteState;

    public Sprite dialogueWindows;
    public ChoiceContent choiceContents;
    public bool makeTea;
    public bool energy;
}

[System.Serializable]
public class DialogueEvent
{
    public string name;

    public Vector2 line;
    public Dialogue[] dialogues;
}