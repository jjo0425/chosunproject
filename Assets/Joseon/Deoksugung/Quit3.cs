using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit3 : MonoBehaviour
{
    public void QuitGame()
    {
        SceneManager.LoadScene("Scene/BackgroundStep");
    }
}
