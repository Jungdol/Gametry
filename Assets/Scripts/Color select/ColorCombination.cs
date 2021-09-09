using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCombination : MonoBehaviour
{
   
    public GameObject Color;
    
    public void ColorSetActive()
    {
        Color.SetActive(!Color.active)
    }
}
