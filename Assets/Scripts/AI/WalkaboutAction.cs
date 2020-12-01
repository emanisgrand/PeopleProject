using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Pathfinding {
[CreateAssetMenu(menuName = "Scriptable AI/New Action/Walkabout")]
    public class WalkaboutAction : Action
    {
        Transform randomTransform;
    public override void Act(StateController controller)
    {
        Walk(controller);
    }

    private void Walk(StateController controller)
    {
        randomTransform = FindObjectOfType<Transform>();
        controller.aiDestination.target
            = randomTransform;

        Debug.Log(controller.aiDestination.target);



        if (controller.aiPath.remainingDistance <= 
            controller.aiPath.endReachedDistance && !controller.aiPath.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.aiDestination.target = controller.wayPointList[controller.nextWayPoint];
        }
        
    }
}
}
