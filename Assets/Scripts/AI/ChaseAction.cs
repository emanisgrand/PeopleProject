using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable AI/New Action/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        // controller.navMeshAgent.destination = controller.moveTarget.position;
        // controller.navMeshAgent.Resume();
    }
}
