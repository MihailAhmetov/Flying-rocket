using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    public static int UnlockedLevelCount = 1;

    [SerializeField] private Sprite _unlockedIcon;
    [SerializeField] private Sprite _lockedIcon;
     
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int levelNumber = i + 1;
            transform.GetChild(i).gameObject.name = levelNumber.ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = levelNumber.ToString();

            if (i < UnlockedLevelCount)
            {
                IconChange(i, _unlockedIcon);
                ButtonInteractionChange(i, true);
            }
            else
            {
                IconChange(i, _lockedIcon);
                ButtonInteractionChange(i, false);
            }
        }
    }

    private void IconChange(int objectNumber, Sprite icon)
    {
        transform.GetChild(objectNumber).GetComponent<Image>().sprite = icon;
    }

    private void ButtonInteractionChange(int objectNumer, bool state)
    {
        transform.GetChild(objectNumer).GetComponent<Button>().interactable = state;
    }
}

