using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable AI/New Action/Walkabout")]
public class WalkaboutAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.navMeshAgent.Resume();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance
            && !controller.navMeshAgent.pathPending)
        {
            // don't exceed the length of the waypoint list. 
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
        
    }
}
