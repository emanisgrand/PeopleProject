using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class basicStats
{

    public int Focus,
        MaxFocus,
        Commitment,
        Transparency,
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
        return Transparency;
    }

    public int getRespect()
    {
        return Respect;
    }

    public int getCourage()
    {
        return Courage;
    }

    public basicStats(int focus, int commitment, int transparency, int respect, int courage)
    {
        MaxFocus = focus;
        Commitment = commitment;
        Transparency = transparency;
        Respect = respect;
        Courage = courage;
        Focus = MaxFocus;
    }

    public basicStats()
    {
        MaxFocus = 25;
        Commitment = 1;
        Transparency = 1;
        Respect = 1;
        Courage = 1;
        Focus = MaxFocus;
    }
}
