using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoff : MonoBehaviour
{

    private bool isTurnOn = true;
    public List<GameObject> objs = new List<GameObject>();




    public void OnClickBtn()
    {
        if (isTurnOn == true) //현재 켜져있는 상태 -> 꺼줘야된다.
        {
            SetVisible(false);
        }
        else // 현재 꺼져있는 상태 -> 켜줘야된다.
        {
            SetVisible(true);
        }

        isTurnOn = !isTurnOn;
    }

    private void SetVisible(bool isVisible)
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(isVisible);
        }
    }
}
