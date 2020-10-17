using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeun : MonoBehaviour
{

    public void PlayGame1 ()
    {
        SceneManager.LoadScene("Scene/CharacterGame");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("Scene/BackgroundStep");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
