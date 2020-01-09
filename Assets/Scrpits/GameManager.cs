using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool gameHasEnded = false;

    public GameObject panel;
    //public static GameManager instance;
   /* void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }*/

    private void Update()
    {
        if (gameHasEnded == true)
        {
            panel.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (FindObjectOfType<Timer>().timeLeft < 0)
            {
                OutOfTime();
            }
        }
    }
    public void Dead()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", 2);
        }
    }
    void Restart()
    {
        gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        panel.SetActive(false);
    }
    void OutOfTime()
    {
            FindObjectOfType<Timer>().timer.SetActive(false);
            FindObjectOfType<DoorOpening>().timerOn = false;
            FindObjectOfType<Timer>().timeLeft = 60;
            Dead();
    }
}
