using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.IO;

public class UIScreenCapture : MonoBehaviour
{
    private Dictionary<int, bool> _stateDictionary = new Dictionary<int, bool>();
    public GameObject[] deActiveObjects;

    public Image textBg;
    public Text textLabel;


    Coroutine _captureRoutine;

    private void Awake()
    {
        textBg.gameObject.SetActive(false);
        textLabel.gameObject.SetActive(false);
    }

    public void Capture()
    {
        if (_captureRoutine != null)
        {
            StopCoroutine(_captureRoutine);
            _captureRoutine = null;
        }

        textBg.color = new Color(1, 1, 1, 1);
        textLabel.color = new Color(0, 0, 0, 1);
        _captureRoutine = StartCoroutine(ProcCapture());
    }


    private IEnumerator ProcCapture()
    {
        textBg.gameObject.SetActive(false);
        textLabel.gameObject.SetActive(false);

        foreach (var item in deActiveObjects)
        {
            _stateDictionary[item.GetInstanceID()] = item.activeSelf;
            item.SetActive(false);
        }

        yield return null;
        if (Application.isEditor == false)
        {
            var m_LastCameraTexture = ScreenCapture.CaptureScreenshotAsTexture();
            var bytes = m_LastCameraTexture.EncodeToPNG();
            NativeGallery.SaveImageToGallery(bytes, "Josun", $"SaveCapture_{System.DateTime.Now.ToString("yyyyMMdd_hhmmss")}.png");
        }

        textLabel.text = $"이미지가 저장되었습니다.\r\n SaveCapture_{System.DateTime.Now.ToString("yyyyMMdd_hhmmss")}.png";
        foreach (var item in deActiveObjects)
        {
            item.SetActive(_stateDictionary[item.GetInstanceID()]);
        }

        yield return new WaitForSeconds(0.5f);
        textBg.gameObject.SetActive(true);
        textLabel.gameObject.SetActive(true);
        for (float a = 1; a > 0;)
        {
            textBg.color = new Color(1, 1, 1, a);
            textLabel.color = new Color(0, 0, 0, a);
            a -= Time.deltaTime;
            yield return null;
        }
        _stateDictionary.Clear();
        textBg.gameObject.SetActive(false);
        textLabel.gameObject.SetActive(false);
    }

}
