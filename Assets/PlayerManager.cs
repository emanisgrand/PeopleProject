using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerManager : basicStats
{

    public float focusPercentage
    {
        get {
            return ((float)Focus / (float)MaxFocus) * 100;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
