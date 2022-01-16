using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaDes : MonoBehaviour
{
    public GameObject[] teaDesGameObject;
    Text[] teaDes = new Text[7];
    TeaStatus teaStatus = new TeaStatus();

    void Start()
    {
        for (int i = 0; i < teaDesGameObject.Length; i++)
        {
            teaDes[i] = teaDesGameObject[i].transform.GetChild(1).GetComponent<Text>();
            teaDes[i].text = teaStatus.SetTeaStatus((TeaMaterial)i).name;

        }
    }
}
