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
}
