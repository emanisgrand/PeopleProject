using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public Action OnPrintAction;

    public GameObject paperPrefab;

    private void Awake()
    {
        //OnPrintAction += PrintAction;
    }

    public void PrintAction()
    {
        Instantiate(paperPrefab, transform.forward * 1.5f, Quaternion.identity);
    }
}
