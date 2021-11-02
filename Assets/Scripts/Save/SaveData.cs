using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum day
{
    morning,
    afternoon,
    evening
}
[System.Serializable]
public class SaveData
{
    public int a_Few_Days;
    public int tree_Level;
    public day now_Day;
    public int happy_Index;
}
