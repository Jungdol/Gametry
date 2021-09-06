using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceContent : MonoBehaviour
{
    [SerializeField]
    public Choice choice;

    public bool flag;
    int result;
    // Start is called before the first frame update
    public void Trigger()
    {
        if (!flag)
        {
            StartCoroutine(ChoiceCoroutine());
        }
    }

    IEnumerator ChoiceCoroutine()
    {
        flag = true;
        var system = FindObjectOfType<ChoiceManager>();
        system.ShowChoice(choice);
        yield return new WaitUntil(() => !system.isChoice);

        result = system.GetResult();
        flag = false;
    }

    public int GetResult()
    {
        return result;
    }
}
