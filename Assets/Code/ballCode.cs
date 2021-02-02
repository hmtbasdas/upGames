using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ballCode : MonoBehaviour
{
    Rigidbody2D rigi;
    public float speed;
    public TextMeshProUGUI goldText;
    int gold = 0;
    public AudioSource goldSound;

    bool lTF = false,rTF = false;

    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "floor" || collider.gameObject.tag == "floorQu")
        {
            rigi.AddForce(transform.up * speed * Time.deltaTime);

            rigi.velocity = new Vector2(0,0);
        }
        if (collider.gameObject.tag == "timeFloor")
        {
            rigi.AddForce(transform.up * speed * Time.deltaTime);
            rigi.velocity = new Vector2(0, 0);
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "upPower")
        {
            rigi.AddForce(transform.up * (speed * 2) * Time.deltaTime);
            rigi.velocity = new Vector2(0, 0);
        }
        
        if (collider.gameObject.tag == "gameOver")
        {
            //SceneManager.LoadScene(1);
            rigi.velocity = new Vector2(0, 0);
            gameObject.transform.position = new Vector2(0, -1.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "qu")
        {

            //collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "sun")
        {
            if(PlayerPrefs.GetInt("vToggle") == 1)
            {
                Handheld.Vibrate();
            }
            if (PlayerPrefs.GetInt("Level") == (PlayerPrefs.GetInt("startLevel")-1))
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            }
            gameObject.SetActive(false);

            PlayerPrefs.SetInt("Gold",PlayerPrefs.GetInt("Gold") + int.Parse(goldText.text));
            SceneManager.LoadScene(0);
        }

        if (collider.gameObject.tag == "gold")
        {
            gold++;
            if (PlayerPrefs.GetInt("sToggle") == 1)
            {
                goldSound.Play();
            }
            //collider.gameObject.SetActive(false);
            Destroy(collider.gameObject);
            goldText.text = gold.ToString();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(5.0f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-5.0f * Time.deltaTime, 0, 0);
        }


        if (rTF)
        {
            if (gameObject.transform.position.x < 2.532)
            {
                gameObject.transform.position += new Vector3(5.0f * Time.deltaTime, 0, 0);
            }
        }
        if (lTF)
        {
            if (gameObject.transform.position.x > -2.532)
            {
                gameObject.transform.position += new Vector3(-5.0f * Time.deltaTime, 0, 0);
            }
        }
    }

    public void leftTrue()
    {
        lTF = true;
    }
    public void leftFalse()
    {
        lTF = false;
    }
    public void rightTrue()
    {
        rTF = true;
    }
    public void rightFalse()
    {
        rTF = false;
    }
    
}
