using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCalculator : MonoBehaviour
{
    public static int itemCount = 0;
    public static float startTime;
    public static float endTime;
    public static bool gameClear = false;
    private float elapsedTime;
    private float standardTime = 100f;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        elapsedTime = startTime - endTime;
        if (gameClear)
        {
            score = 1000 * (standardTime - elapsedTime) + 10000 * itemCount;
        } else
        {
            score = 10000 * itemCount;
        }
        Debug.Log(score);
    }
}
