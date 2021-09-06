using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject Image;
    public DialogueTrigger dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialouge());
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    IEnumerator StartDialouge()
    {
        yield return new WaitForSeconds(1f);
        Image.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        dialogueTrigger.Trigger();
    }
}
