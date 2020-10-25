
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backgrond : MonoBehaviour
{
    [Tooltip ("The drop down box to populate with flags")]
    public Dropdown dropdown;

    [Tooltip("The flags of the languages that our supports")]
    public Sprite[] flags;

    void Start()
    {
        dropdown.ClearOptions();

        List<Dropdown.OptionData> flagItem = new List<Dropdown.OptionData>();

        foreach ( var flag in flags)
        {
            string flagName = flag.name;
            int dot = flag.name.IndexOf('.');
            if (dot>=0)
            {
                flagName = flagName.Substring(dot + 1);
            }

            var flagOption = new Dropdown.OptionData(flagName, flag);
            flagItem.Add(flagOption);
        }

        dropdown.AddOptions(flagItem);
    }

}
