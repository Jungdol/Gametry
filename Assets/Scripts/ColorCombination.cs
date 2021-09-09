using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCombination : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        sr=go.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            sr.material.color = Color.red;
        if (Input.GetKeyDown("g"))
            sr.material.color = Color.green;
        if (Input.GetKeyDown("b"))
            sr.material.color = Color.blue;

        if (Input.GetKeyDown("i"))
            sr.material.color = new Color(0.3f, 0.4f, 0.7f);
    }
}
