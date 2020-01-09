using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public AudioClip soundOn;
    public AudioClip soundOff;
    float battery = 10, maxBattery = 10;
    bool isUsing = false;
    Rect batteryRect;
    Texture2D batteryTexture;

    void Start()
    {
        batteryRect = new Rect(Screen.width / 10, Screen.height * 92 / 100,
         Screen.width / 3, Screen.height / 50);
        batteryTexture = new Texture2D(1, 1);
        batteryTexture.SetPixel(0, 0, Color.red);
        batteryTexture.Apply();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(GetComponent<Light>().enabled == false)
            {
                FindObjectOfType<AudioManager>().Play("LightOn");
                GetComponent<Light>().enabled = true;
                isUsing = true;
            }
            else
            {
                GetComponent<Light>().enabled = false;
                FindObjectOfType<AudioManager>().Play("LightOff");
                isUsing = false;
            }
        }
        if (isUsing)
        {
            battery -= Time.deltaTime;
            if (battery < 0)
            {
                battery = 0;
                GetComponent<Light>().enabled = false;
                isUsing = false;
            }
        }
        else if (battery < maxBattery)
        {
            battery += Time.deltaTime / 2;
        }
    }
    void OnGUI()
    {
        float ratio = battery / maxBattery;
        float rectWidth = ratio * Screen.width / 3;
        batteryRect.width = rectWidth;
        GUI.DrawTexture(batteryRect, batteryTexture);
    }
}

