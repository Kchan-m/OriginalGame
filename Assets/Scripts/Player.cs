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
    private float spirit = 100;
    private float maxSpirit = 100;
    public Slider slider;

    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("DecreaseSpirit", 0, 1);
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
            SceneManager.LoadScene("GameOver");
        }

        if (spirit <= 0)
        {
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
            SceneManager.LoadScene("GameClear");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            if (spirit > maxSpirit - 10) spirit = maxSpirit;
            else spirit += 10;
            slider.value = spirit / maxSpirit;
            Destroy(collision.gameObject);
        }
    }

    private void DecreaseSpirit()
    {
        spirit -= 2.5f;
        slider.value = spirit / maxSpirit;
    }
}
