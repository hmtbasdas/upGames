using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerCode : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject ball;
    public Sprite[] balls;
    public GameObject wall;

    void Start()
    {
        //Debug.Log("Oyun Level : " +PlayerPrefs.GetInt("startLevel"));
        Instantiate(levels[PlayerPrefs.GetInt("startLevel") - 1], new Vector3(0,0,0), Quaternion.identity);
        

        ball.GetComponent<SpriteRenderer>().sprite = balls[int.Parse(PlayerPrefs.GetString("SelectedBall").Substring(4, 1))];

        float NormalSize = 16.0f / 9.0f;
        float ScreenSize = (float)Screen.height / (float)Screen.width;

        float WallY = (NormalSize * 2.5f) / ScreenSize;
        wall.GetComponent<Transform>().position = new Vector3(0, WallY, 0);
    }
    public void goHome()
    {
        SceneManager.LoadScene(0);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        
    }
}
