using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("맨 처음 등장할 때")]
    public Sprite firstSprite;

    [Header("차 마시는 이미지")]
    public Sprite tasteTeaSprite;

    [HideInInspector]
    public DialogueManager dialogueManager;

    [SerializeField]
    public Dialogue[] dialogue;
    public DialogueTrigger[] energyDialogues;
    [Header("차 좋음, 보통")] 
    public TeaMaterial[] teaFinishNum;
    public DialogueTrigger[] teaFinishDialogues;

    TeaCreate teaCreate;
    TeaSelect teaSelect;
    StageChange stageChange;

    private void Start()
    {
        teaCreate = FindObjectOfType<TeaCreate>();
        teaSelect = FindObjectOfType<TeaSelect>();
        stageChange = FindObjectOfType<StageChange>();
    }
    public void OnTrigger() // 버튼 전용
    {
        Trigger();
    }

    public void TeaChoiceDialogue()
    {
        Debug.Log(teaFinishNum.Length);
        Debug.Log(teaCreate.teaSelect.send_num);
        for (int i = 0; i < teaFinishNum.Length - 1; i++)
        {
            Debug.Log(teaSelect.TeaSelectCases(teaFinishNum[i], teaFinishNum[i + 1], "비교"));
            if (teaCreate.teaSelect.send_num == teaSelect.TeaSelectCases(teaFinishNum[i], teaFinishNum[i+1], "비교"))
            {
                teaFinishDialogues[i].Trigger();
                TeaHappyIndex(i);
                break;
            }
            else if (i == teaFinishNum.Length - 2)
            {
                teaFinishDialogues[2].Trigger();
                stageChange.HappyIndexPlus(-10);
                break;
            }
        }
    }

    void TeaHappyIndex(int i)
    {
        bool isTwoCases(TeaMaterial _teaMaterial1, TeaMaterial _teaMaterial2, TeaMaterial _tempTeaMaterial1 = 0, TeaMaterial _tempTeaMaterial2 = 0)
        {
            if (_tempTeaMaterial1 == _teaMaterial1 && _tempTeaMaterial2 == _teaMaterial2 || _tempTeaMaterial1 == _teaMaterial2 && _tempTeaMaterial2 == _teaMaterial1)
                return true;
            else
                return false;
        }

        if (isTwoCases(teaFinishNum[0], teaFinishNum[1], teaFinishNum[i], teaFinishNum[i + 1]))
            stageChange.HappyIndexPlus(20);
        else if (isTwoCases(teaFinishNum[1], teaFinishNum[2], teaFinishNum[i], teaFinishNum[i + 1]))
            stageChange.HappyIndexPlus(10);
        else
            stageChange.HappyIndexPlus(-10);
    }

    public void ImageSetting()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.rendererImage.sprite = firstSprite;
    }

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.dialogue = dialogue;
        system.dialogueTrigger = this;
        system.ShowDialogue();
    }
}

