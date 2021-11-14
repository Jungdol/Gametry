using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceContent : MonoBehaviour
{
    [SerializeField]
    public Choice choice;
    public int correctAnswer;
    public GameObject[] dialogueTriggers;

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
        GetResult();
        flag = false;
    }

    public int GetResult()
    {
        DialogueTrigger dialogueTrigger = dialogueTriggers[result].GetComponent<DialogueTrigger>();

        dialogueTriggers[result].SetActive(true);
        dialogueTrigger.Trigger();

        if (result == correctAnswer)
        {
            StageChange.instance.happyIndex += 10; // 맞는 답이면 행복지수 10 증가
        }
            

        return result;
    }
}
