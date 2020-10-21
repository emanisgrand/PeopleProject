using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {
    //[SerializeField] private Transform target;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            MoveToCursor();
        }
    }

    private void MoveToCursor()
    {
        int _layerMask = 12;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(_ray, out hit);
        if (hasHit) {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}
