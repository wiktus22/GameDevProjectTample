using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(sceneName: "Scene");
    }
    public void AboutGameBtn(string aboutScene)
    {
        SceneManager.LoadScene(sceneName: "About");
    }
    public void QuitGameBtn()
    {
        Application.Quit();
    }
    public void BackToMenu(string backToMenu)
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
