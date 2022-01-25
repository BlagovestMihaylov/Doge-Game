using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelSelectorController : MonoBehaviour
{
    public List<int> availableLevels = new List<int>();
    private int selectedLevel;
    public TMP_Text levelLabel;

    // Start is called before the first frame update
    void Start()
    {
        selectedLevel = 0;
        UpdateLabel();
    }

    public void Left()
    {
        selectedLevel--;
        if (selectedLevel < 0)
        {
            selectedLevel = 0;
        }
        UpdateLabel();
    }

    public void Right()
    {
        selectedLevel++;
        if (selectedLevel > availableLevels.Count - 1)
        {
            selectedLevel = availableLevels.Count - 1;
        }
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        levelLabel.text = "Level - " + availableLevels[selectedLevel];
    }
}
