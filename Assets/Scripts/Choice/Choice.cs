using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choice
{
    [TextArea(1, 2)]
    public string[] answers; // 답변 (최대 3개)
}