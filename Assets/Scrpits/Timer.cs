using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class Timer : MonoBehaviour
{
    public GameObject timer;
    public int timeLeft = 60;
    public Text countdown;
    bool on = true;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (FindObjectOfType<DoorOpening>().timerOn == true)
        {
            if (on == true)
            {
                timer.SetActive(true);
                StartCoroutine("LoseTime");
                on = false;
            }
        }
            countdown.text = ("" + timeLeft);
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}

