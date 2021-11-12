using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject Image;
    public DialogueTrigger dialogueTrigger;
    //public InteractionEvent interactionEvent;
    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        if (dialogueTrigger.firstSprite != null)
            dialogueTrigger.ImageSetting();
        StartCoroutine(StartDialouge());
        //interactionEvent = GetComponent<InteractionEvent>();
    }

    IEnumerator StartDialouge()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.Play("DoorBell");
        yield return new WaitForSeconds(0.5f);
        Image.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        dialogueTrigger.Trigger();
        //interactionEvent.GetDialogue();
    }
}
