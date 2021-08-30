using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMgr : MonoBehaviour
{
    public GameObject DialogueWindow;

    public Text txtName;
    public Text txtSentence;

    Queue<string> sentences = new Queue<string>();

    public void Begin(Dialogue info)
    {
        DialogueWindow.SetActive(true);

        sentences.Clear();

        txtName.text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }
    
    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = sentences.Dequeue();
    }

    private void End()
    {
        txtSentence.text = string.Empty;

        DialogueWindow.SetActive(false);
    }
}
