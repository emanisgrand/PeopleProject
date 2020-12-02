using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FakeCameraEvent : MonoBehaviour
{
    public Transform EODScreenPosition;
    
    private Vector3 startingPosition;
    private Quaternion startingQuaternion;
    
    private Camera mainCam;

    private void Awake()
    {
        if (!(Camera.main is null)) mainCam = Camera.main.GetComponent<Camera>();
        startingPosition = mainCam.transform.position;
        startingQuaternion = new Quaternion(0.118815735f,0.877471507f,-0.282694221f,0.368796259f);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K pressed.");
            
            Vector3 clockFacing = new Vector3(0, 90, 0);
            transform.eulerAngles = clockFacing;
            
            mainCam.transform.position = EODScreenPosition.position;
            mainCam.orthographic = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed.");
            mainCam.transform.position = startingPosition;
            mainCam.transform.rotation = startingQuaternion;
            mainCam.orthographic = true;
        }
    }
}
