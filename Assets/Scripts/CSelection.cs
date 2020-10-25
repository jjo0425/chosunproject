using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;


    public UnityEngine.UI.Text onOffButnLabel;

    /// <summary>
    /// 캐릭터 리스트
    /// </summary>
    public List<GameObject> characterList;
    /// <summary>
    /// 캐릭터 리스트와 상관없이 On/OFF 될 애들
    /// </summary>
    public List<GameObject> addtionalObjectList;


    private int currentCharacter;
    public bool isVisible = true;

    private void Awake()
    {
        onOffButnLabel.text = "보이기";
        SelectCharacter(0);
        if (isVisible == true) SetVisibleToggle();
    }

    public void SetVisibleToggle()
    {
        if (isVisible == true) // 꺼주는 행동
        {
            onOffButnLabel.text = "보이기";
            foreach (var item in characterList)
            {
                item.SetActive(false);
            }
            foreach(var item in addtionalObjectList)
            {
                item.SetActive(false);
            }
        }
        else if (isVisible == false) // 켜주는 행동
        {
            onOffButnLabel.text = "숨기기";
            SelectCharacter(currentCharacter);
        }

        isVisible = !isVisible;
    }

    private void SelectCharacter(int _index)
    {
        foreach (var item in addtionalObjectList)
        {
            item.SetActive(true);
        }

        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != characterList.Count- 1);

        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].SetActive(i == _index);
         }
    }
    public void ChangeCharacter(int _change)
    {
        currentCharacter += _change;
        SelectCharacter(currentCharacter);
    }
}
