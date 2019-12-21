using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTransparency : MonoBehaviour
{
    Image image;
    [SerializeField] GameObject manager;
    
    void Start()
    {
        image = GetComponent<Image>();
        Color c = image.color;
        c.a = 1f;
        image.color = c;

    }
   

}
