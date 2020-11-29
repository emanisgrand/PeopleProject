using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeamStats 
{
    public int documentation = 1,
        quality = 1,
        feedback = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getDocumentation()
    {
        return documentation;
    }

    public int getQuality()
    {
        return quality;
    }

    public int getFeedback()
    {
        return feedback;
    }
}
