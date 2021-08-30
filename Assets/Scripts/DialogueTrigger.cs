using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueMgr>();
        system.Begin(info);
    }
}
