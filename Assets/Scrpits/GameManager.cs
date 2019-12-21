using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public GameObject panel;
    private void Update()
    {
        if(gameHasEnded == true)
        {
            panel.SetActive(true);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
