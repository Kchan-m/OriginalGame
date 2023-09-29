using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Se : MonoBehaviour
{
    public AudioSource se;
    public AudioClip jumpOne;
    public AudioClip jumpTwo;
    public AudioClip itemGet;
    public AudioClip gameClear;
    public AudioClip gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump1()
    {
        se.PlayOneShot(jumpOne);
    }

    public void Jump2()
    {
        se.PlayOneShot(jumpTwo);
    }

    public void Getitem()
    {
        se.PlayOneShot(itemGet);
    }

    public void GameClear()
    {
        se.PlayOneShot(gameClear);
    }

    public void GameOver()
    {
        se.PlayOneShot(gameOver);
    }
}
