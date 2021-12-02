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
    public GameObject pullWave;
    public GameObject pushWave;
    public GameObject gravity;
    public GameObject pullBorder;
    public GameObject pushBorder;
    public GameObject gravityBorder;
    public int levelNum;
    public int attempts;
    public int pushNums;
    public int pullNums;

    private void Start()
    {
        curLevel = levels[data.curLevel];
        levelNum = curLevel.levelNum;
        attempts = curLevel.attempts;
        pushNums = curLevel.pushNum;
        pullNums = curLevel.pullNum;
        levelNumText.GetComponent<TextMeshProUGUI>().text = levelNum.ToString();
        gravity.GetComponent<Animator>().SetBool("gravSelected", true);
        pushBorder.SetActive(false);
        pullBorder.SetActive(false);
    }

    private void Update()
    {
        UpdateText();
        CheckInputs();
    }

    void UpdateText()
    {
        attemptsText.GetComponent<TextMeshProUGUI>().text = attempts.ToString();
        pushNumText.GetComponent<TextMeshProUGUI>().text = pushNums.ToString();
        pullNumText.GetComponent<TextMeshProUGUI>().text = pullNums.ToString();
    }

    public void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pullWave.GetComponent<Animator>().SetBool("pullSelected", false);
            pushWave.GetComponent<Animator>().SetBool("pushSelected", true);
            gravity.GetComponent<Animator>().SetBool("gravSelected", false);
            pushBorder.SetActive(true);
            pullBorder.SetActive(false);
            gravityBorder.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pullWave.GetComponent<Animator>().SetBool("pullSelected", true);
            pushWave.GetComponent<Animator>().SetBool("pushSelected", false);
            gravity.GetComponent<Animator>().SetBool("gravSelected", false);
            pushBorder.SetActive(false);
            pullBorder.SetActive(true);
            gravityBorder.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pullWave.GetComponent<Animator>().SetBool("pullSelected", false);
            pushWave.GetComponent<Animator>().SetBool("pushSelected", false);
            gravity.GetComponent<Animator>().SetBool("gravSelected", true);
            pushBorder.SetActive(false);
            pullBorder.SetActive(false);
            gravityBorder.SetActive(true);
        }
    }
}
