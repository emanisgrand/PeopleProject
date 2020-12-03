using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlledMovement : MonoBehaviour
{
    public float dragSpeed = 0.5f;
    private Vector3 dragOrigin;
 
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.endOfDay)
        {
            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(0) || GameManager.instance.endOfDay) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
 
        transform.Translate(move, Space.World);  
    }
}
