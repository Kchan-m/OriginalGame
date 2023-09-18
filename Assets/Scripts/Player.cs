using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 280f;
    public float defaultJumpPower = 280f;
    private int jumpCount = 0;
    public static float maxSpirit = 100f;
    public static float spirit = maxSpirit;
    public Slider slider;

    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCalculator.gameClear = false;
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        if (GameRetry.beforeSceneName == "Stage1")
        {
            InvokeRepeating("DecreaseSpiritLevel1", 0, 1);
        } else if (GameRetry.beforeSceneName == "Stage2")
        {
            InvokeRepeating("DecreaseSpiritLevel2", 0, 1);
        } else if (GameRetry.beforeSceneName == "Stage3")
        {
            InvokeRepeating("DecreaseSpiritLevel3", 0, 1);
        }
        spirit = maxSpirit;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
        {
            playerRigidbody.AddForce(transform.up * jumpPower);
            jumpCount++;
        } else if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {
            jumpPower = 200f;
            playerRigidbody.AddForce(transform.up * jumpPower);
            jumpCount++;
        }

        if (this.gameObject.transform.position.y <= -20f)
        {
            ScoreCalculator.endTime = Time.time;
            SceneManager.LoadScene("GameOver");
        }

        if (spirit <= 0)
        {
            ScoreCalculator.endTime = Time.time;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(speed, playerRigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stage"))
        {
            jumpCount = 0;
            jumpPower = 280f;
        }

        if (other.gameObject.CompareTag("Oshi"))
        {
            ScoreCalculator.endTime = Time.time;
            SceneManager.LoadScene("GameClear");
            ScoreCalculator.gameClear = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            if (spirit > maxSpirit - 10) spirit = maxSpirit;
            else spirit += 10;
            slider.value = spirit / maxSpirit;
            ScoreCalculator.itemCount++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Rival"))
        {
            ScoreCalculator.rivalCounter++;
            spirit -= 10;
            slider.value = spirit / maxSpirit;
        }
    }

    private void DecreaseSpiritLevel1()
    {
        spirit -= 2.5f;
        slider.value = spirit / maxSpirit;
    }

    private void DecreaseSpiritLevel2()
    {
        spirit -= 3f;
        slider.value = spirit / maxSpirit;
    }

    private void DecreaseSpiritLevel3()
    {
        spirit -= 3.5f;
        slider.value = spirit / maxSpirit;
    }
}
