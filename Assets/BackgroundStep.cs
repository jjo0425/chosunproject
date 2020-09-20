using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundStep : MonoBehaviour
{

    public void PlayGame3()
    {
        SceneManager.LoadScene("Scene/Background1");
    }

    public void PlayGame4()
    {
        SceneManager.LoadScene("Scene/Back2");
    }

    public void PlayGame5()
    {
        SceneManager.LoadScene("Scene/Back3");
    }

    public void PlayGame6()
    {
        SceneManager.LoadScene("Scene/Back4");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scene/MainMenu");
    }
}
