using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class basicStats
{

    public int Focus,
        MaxFocus,
        Commitment,
        Openness,
        Respect,
        Courage;


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

    public basicStats(int focus, int commitment, int openness, int respect, int courage)
    {
        MaxFocus = focus;
        Commitment = commitment;
        Openness = openness;
        Respect = respect;
        Courage = courage;
        Focus = MaxFocus;
    }

    public basicStats()
    {
        MaxFocus = 10;
        Commitment = 1;
        Openness = 1;
        Respect = 1;
        Courage = 1;
        Focus = MaxFocus;
    }
}
