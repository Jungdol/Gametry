using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    public SpriteRenderer background;
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)3 / 4);
        float scalewidth = 1f * scaleheight;
        float spriteHeight = 1f * scalewidth;

        background.transform.localScale = new Vector3 (scalewidth, spriteHeight, background.transform.localScale.z);
    }
    
}
