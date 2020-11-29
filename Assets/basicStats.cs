using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class basicStats
{

    public int Focus = 10,
        maxFocus = 10,
        Commitment = 1,
        Openness = 1,
        Respect = 1,
        Courage = 1;


    public int getFocus()
    {
        return Focus;
    }

    public int getCommitment()
    {
        return Commitment;
    }

    public int getOpenness()
    {
        return Openness;
    }

    public int getRespect()
    {
        return Respect;
    }

    public int getCourage()
    {
        return Courage;
    }
}
