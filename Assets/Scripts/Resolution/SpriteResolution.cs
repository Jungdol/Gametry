using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteResolution : MonoBehaviour
{
    public SpriteRenderer background;
    void Awake()
    {
        SetSpriteRatio();
    }

    void SetSpriteRatio()
    {
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)3f / 4f);
        float scalewidth = 1f * scaleheight;
        float spriteHeight = 1f * scalewidth;
        Debug.Log(scalewidth);
        Debug.Log(spriteHeight);

        background.transform.localScale = new Vector3(scalewidth, spriteHeight, background.transform.localScale.z);
    }
}
