using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerManager : basicStats
{
    public float CurrentFocus = 100f, MaxFocus = 100f;
    public float focusPercentage
    {
        get {
            return (CurrentFocus / MaxFocus) * 100f;
        }
    }

    [Header("Stat Levels")]
    public int FocusLevel;
    public int CommitmentLevel,
        TransparencyLevel,
        RespectLevel,
        CourageLevel;

    [Header("Stat Levels")]
    public int[] FocusLevelPoints;
    public int[] CommitmentLevelPoints,
        TransparencyLevelPoints,
        RespectLevelPoints,
        CourageLevelPoints;

    [Header("Player Stats")]
    public int talentPoints;
    public int playerLevel;
    public int playerEXP;

    public int[] playerEXPToLevel;


    public void decFocus(float min, float max)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        float amount = Random.Range(min, max);

        CurrentFocus -= amount;
    }

    public void incFocus(float min, float max)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        float amount = Random.Range(min, max);

        CurrentFocus += amount;
    }

    public void checkForLevelUp()
    {
        if(Focus > FocusLevelPoints[FocusLevel - 1])
        {
            FocusLevel++;
            playerEXP += 1;
        }

        if (Commitment > CommitmentLevelPoints[FocusLevel - 1])
        {
            CommitmentLevel++;
            playerEXP += 1;
        }

        if (Courage > CourageLevelPoints[FocusLevel - 1])
        {
            CourageLevel++;
            playerEXP += 1;
        }

        if (Respect > RespectLevelPoints[FocusLevel - 1])
        {
            RespectLevel++;
            playerEXP += 1;
        }

        if (Transparency > TransparencyLevelPoints[FocusLevel - 1])
        {
            TransparencyLevel++;
            playerEXP += 1;
        }

        if(playerEXP > playerEXPToLevel[playerLevel - 1])
        {
            playerLevel++;
            talentPoints++;
        }
    }
}
