using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endsc : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit();

    }

    // Update is called once per frame
    void Update()
    {
        Application.Quit();
    }
}
