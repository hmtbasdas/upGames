using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraCode : MonoBehaviour
{
    Transform ballTransform;
    GameObject[] floorL;
    GameObject[] upFloorL;
    int floorLenght = 0;

    bool floorObj = true;

    void Start()
    {
        ballTransform = GameObject.Find("Ball").transform;

        float NormalSize = 16.0f / 9.0f;
        float ScreenSize = (float)Screen.height / (float)Screen.width;

        float CameraSize = (ScreenSize * 5) / NormalSize;

        gameObject.GetComponent<Camera>().orthographicSize = CameraSize;
    }

    void Update()
    {
        if (floorObj)
        {
            floorL = GameObject.FindGameObjectsWithTag("floor");
            upFloorL = GameObject.FindGameObjectsWithTag("upPower");
            Debug.Log("floor sayisi : " + (floorL.Length + upFloorL.Length));
            floorLenght = floorL.Length + upFloorL.Length;
            floorObj = false;
        }
        transform.position = new Vector3(0,Mathf.Clamp(ballTransform.position.y,0,floorLenght*20 + 3),-10);
    }
}
