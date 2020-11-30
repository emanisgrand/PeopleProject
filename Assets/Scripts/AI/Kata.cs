using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kata : MonoBehaviour
{
    public List<Transform> TransformList;

    private void Awake()
    {
        
        TransformList = GetComponent<Kata>().TransformList;
    }

    // Update is called once per frame
    void Update()
    {
        TransformList.Shuffle();
    }
}
