using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BeatLevelScript : MonoBehaviour
{
    public GameObject attempts;
    public GameData data;
    int numAttempts;

    // Start is called before the first frame update
    void Start()
    {
        numAttempts = data.score;
        attempts.GetComponent<TextMeshProUGUI>().text = numAttempts.ToString();
    }

    public void NextLevel()
    {
        data.curLevel += 1;
        SceneManager.LoadScene(2*data.curLevel+1);
    }
}
