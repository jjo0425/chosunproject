using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CI : MonoBehaviour
{
    public Slider _slider;

    private void Start()
    {
        _slider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) == true)
        {
            StartCoroutine(StartGame());
        }
    }
    IEnumerator StartGame()
    {
        _slider.gameObject.SetActive(true);
        AsyncOperation oper = SceneManager.LoadSceneAsync(1);

        while (oper.isDone == false)
        {
            _slider.value = oper.progress;
            yield return null;
        }
        _slider.value = 1;
    }
}
