using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneChange()
    {
        LoadingSceneController.LoadScene("end");
    }
}
