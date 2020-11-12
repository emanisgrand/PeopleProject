using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBehavior : MonoBehaviour
{
   public float WeightMultiplier = 1;
   public float TimePassed = 0;
   public abstract float GetWeight();
   public abstract void Execute();
}
