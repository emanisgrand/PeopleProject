using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AstarAI : MonoBehaviour
{
   public Transform targetPosition;

   private void Start()
   {
      Seeker seeker = GetComponent<Seeker>();
      seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
   }


   public void OnPathComplete(Path p)
   {
      Debug.Log("Check for errors? " + p.error);
   }
}
