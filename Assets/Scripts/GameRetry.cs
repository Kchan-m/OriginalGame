using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRetry : MonoBehaviour
{
    public static string beforeSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNextButton()
    {
        if (beforeSceneName == "Stage1")
        {
            beforeSceneName = "Stage2";
            ScoreCalculator.itemCount = 0;
            ScoreCalculator.rivalCounter = 0;
            SceneManager.LoadScene("Stage2");
        }
        else if (beforeSceneName == "Stage2")
        {
            ScoreCalculator.itemCount = 0;
            ScoreCalculator.rivalCounter = 0;
            beforeSceneName = "Stage3";
            SceneManager.LoadScene("Stage3");
        }
    }

    public void OnClickRetryButton()
    {
        ScoreCalculator.itemCount = 0;
        ScoreCalculator.rivalCounter = 0;
        SceneManager.LoadScene(beforeSceneName);
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
