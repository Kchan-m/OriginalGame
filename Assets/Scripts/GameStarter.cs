using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStage1Button()
    {
        SceneManager.LoadScene("Stage1");
        GameRetry.beforeSceneName = "Stage1";
        ScoreCalculator.startTime = Time.time;
    }

    public void OnClickStage2Button()
    {
        SceneManager.LoadScene("Stage2");
        GameRetry.beforeSceneName = "Stage2";
        ScoreCalculator.startTime = Time.time;
    }

    public void OnClickStage3Button()
    {
        SceneManager.LoadScene("Stage3");
        GameRetry.beforeSceneName = "Stage3";
        ScoreCalculator.startTime = Time.time;
    }
}
