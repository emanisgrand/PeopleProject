using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDoNothing : AiBehavior
{
    public float ReturnWeight = 0.5f;
    public override float GetWeight()
    {
        return ReturnWeight;
    }

    public override void Execute()
    {
        Debug.Log("Lounging");   
    }
}
