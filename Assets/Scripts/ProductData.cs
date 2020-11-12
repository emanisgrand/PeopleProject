using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ProductData : MonoBehaviour
{
  public enum OutComes
  {
    EOD,EOW,EOM,EOQ
  }
  
  public string Name;

  public Transform DeliverySpot;
  
  public bool IsGood;
  
  // if good, then green. otherwise, red.
  public Color OutcomeColor;

  // based on cost, player, and employeeAI contribution
  public float QualityScore;
}
