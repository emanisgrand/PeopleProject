using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Pathfinding {
[CreateAssetMenu(menuName = "Scriptable AI/New Action/Walkabout")]
    public class WalkaboutAction : Action
{
    public override void Act(StateController controller)
    {
        Walk(controller);
    }

    private void Walk(StateController controller)
    {
        controller.aiDestination.target.position = controller.wayPointList[controller.nextWayPoint].position;

        
        if (controller.aiPath.remainingDistance <= 
            controller.aiPath.endReachedDistance && !controller.aiPath.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
        
    }
}
}
