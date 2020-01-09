using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : MonoBehaviour
{
    float stamina = 5, maxStamina = 5;
    float walkSpeed, runSpeed;
    PlayerMovement pm;
    bool isRunning;
    Rect staminaRect;
    Texture2D staminaTexture;
    bool isPlaying = false;
    void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        walkSpeed = pm.movement;
        runSpeed = 14f;

        staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10,
            Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.white);
        staminaTexture.Apply();
    }
    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        pm.movement = isRunning ? runSpeed : walkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetRunning(false);
        }
        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }
        else if (stamina < maxStamina)
        {
            stamina += Time.deltaTime;
        }
        if ((stamina < maxStamina / 2) && (isPlaying == false))
        {
            FindObjectOfType<AudioManager>().Play("HeavyBreath");
            isPlaying = true;
        }
        else if (stamina > maxStamina / 2 && isPlaying == true) isPlaying = false;
    }

    void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidth = ratio * Screen.width / 3;
        staminaRect.width = rectWidth;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }
}

