using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragscript : MonoBehaviour, IDragHandler
{
    public Image _tagetImage;
    public void OnDrag(PointerEventData eventData)
    {
        _tagetImage.transform.position += new Vector3(eventData.delta.x,0);
    }
}
