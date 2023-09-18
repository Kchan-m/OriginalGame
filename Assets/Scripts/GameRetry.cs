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

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene(beforeSceneName);
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
