using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            NewMethod();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        void NewMethod()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion Singleton

    public int happyIndex = 0;
    public int happyMax = 100;

    public int treeLevel;

    // Start is called before the first frame update
    void Start()
    {
        happyIndex = DataManager.instance.happy_Index;
        treeLevel = DataManager.instance.tree_Level;
    }

    private void Update()
    {
        if (happyIndex >= 100)
        {
            treeLevel++;
            happyIndex = 0;
        }
    }
}
