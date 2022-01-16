using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CutSceneManager : MonoBehaviour
{
    public Image cutSceneImage;
    public Text text;
    public Sprite[] cutScenes;

    [TextArea(3, 5)]
    public List<string> listSentences;

    int count;

    float dialogSpeed = 0.1f;
    private float temp = 0;

    int i;

    // Start is called before the first frame update
    void Start()
    {
        dialogSpeedSave();
        ShowCutScene();

        AudioManager.instance.Play("CutScene");
    }

    void ShowCutScene()
    {
        if (DataManager.instance.a_Few_Days == 3)
            count = 4;
        else
            count = 0;

        StartCoroutine(StartCutScene());
    }

    public void NextCutScene()
    {
        if (i < listSentences[count].Length)
        {
            Debug.Log("적용");
            dialogSpeed = 0.001f;
        }

        else if (i >= listSentences[count].Length)
        {
            count++;
            text.text = "";

            if (DataManager.instance.a_Few_Days != 3 && count == 4)
            {
                AudioManager.instance.Stop("CutScene");
                LoadingSceneController.LoadScene("GameScene");
            }

            else
            {
                StopAllCoroutines();
                StartCoroutine(StartCutScene());
            }
        }
        
        else
        {
            
        }
    }

    IEnumerator StartCutScene()
    {
        cutSceneImage.sprite = cutScenes[count];

        dialogSpeedImport();

        // 한글자씩 출력
        for (i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i];
            yield return new WaitForSeconds(dialogSpeed);
        }
    }

    void dialogSpeedSave()
    {
        temp = dialogSpeed;
    }

    // 대화창 출력 속도를 temp에서 불러옴
    void dialogSpeedImport()
    {
        dialogSpeed = temp;
    }
}
