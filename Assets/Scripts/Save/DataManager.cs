using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    //[HideInInspector]
    //public AbilityManager abilityManager;
    public int a_Few_Days = 0;
    public int tree_Level = 0;
    public day now_Day = day.morning;
    public int happy_Index = 0;
    [HideInInspector]
    public bool isData = false;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        CheckData();
    }

    public void SaveData()
    {
        SaveData save = new SaveData();
        save.a_Few_Days = a_Few_Days;
        save.tree_Level = tree_Level;
        save.now_Day = now_Day;
        save.happy_Index = happy_Index;
        SaveManager.Save(save);
    }

    public void LoadData()
    {
        SaveData save = SaveManager.Load();
        a_Few_Days = save.a_Few_Days;
        tree_Level = save.tree_Level;
        now_Day = save.now_Day;
        happy_Index = save.happy_Index;
        save.tree_Level = tree_Level;
    }

    public void CheckData()
    {
        SaveData save = SaveManager.Load();
        if (save == default)
            isData = false;
        else
            isData = true;
    }

    public void ResetData()
    {
        SaveData save = new SaveData();
        a_Few_Days = 0;
        tree_Level = 0;
        now_Day = day.morning;
        happy_Index = 0;
        SaveManager.Save(save);
    }
}
