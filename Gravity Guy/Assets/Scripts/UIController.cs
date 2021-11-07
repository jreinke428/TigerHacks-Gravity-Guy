using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject levelNumText;
    public GameObject attemptsText;
    public GameObject pushNumText;
    public GameObject pullNumText;
    public LevelData[] levels;
    public LevelData curLevel;
    public GameData data;
    public int levelNum;
    public int attempts;
    public int pushNums;
    public int pullNums;

    private void Start()
    {
        curLevel = levels[data.curLevel];
        levelNum = curLevel.levelNum;
        attempts = curLevel.attempts;
        pushNums = curLevel.pullNum;
        pullNums = curLevel.pullNum;
        levelNumText.GetComponent<TextMeshProUGUI>().text = levelNum.ToString();
    }

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        attemptsText.GetComponent<TextMeshProUGUI>().text = attempts.ToString();
        pushNumText.GetComponent<TextMeshProUGUI>().text = pushNums.ToString();
        pullNumText.GetComponent<TextMeshProUGUI>().text = pullNums.ToString();
    }
}
