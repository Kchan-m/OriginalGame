using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public Text rankText;
    public static int sumScore;
    private int[] rankValue = { 0, 150000, 500000, 1000000, 1500000, 2500000 };
    private string[] rankName = { "研修生", "駆け出し新人アイドル", "期待のアイドル", "人気アイドル", "大人気アイドル", "国民的アイドル" };

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = Mathf.Floor(ScoreCalculator.score).ToString();
        sumScore = PlayerPrefs.GetInt("SUMSCORE", 0);
        sumScore += (int)ScoreCalculator.score;
        PlayerPrefs.SetInt("SUMSCORE", sumScore);
        PlayerPrefs.Save();
        if (rankValue[0] <= sumScore && sumScore < rankValue[1])
        {
            rankText.text = rankName[0];
        } else if (rankValue[1] <= sumScore && sumScore < rankValue[2])
        {
            rankText.text = rankName[1];
        } else if (rankValue[2] <= sumScore && sumScore < rankValue[3])
        {
            rankText.text = rankName[2];
        } else if (rankValue[3] <= sumScore && sumScore < rankValue[4])
        {
            rankText.text = rankName[3];
        } else if (rankValue[4] <= sumScore && sumScore < rankValue[5])
        {
            rankText.text = rankName[4];
        } else
        {
            rankText.text = rankName[5];
        }
        Debug.Log(sumScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
