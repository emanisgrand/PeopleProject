using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable AI/New Action/Execute")]
public class ExecuteAction : Action
{
    public override void Act(StateController controller)
    {
        Execute(controller);
    }

    private void Execute(StateController controller)
    {
        RaycastHit hit;
        
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized 
        * 5f, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.Data.lookSphereCastRadius, controller.eyes.forward,
            out hit, controller.Data.visionDistance) && hit.collider.GetComponent<OfficeObject>().enabled)
        {
            if (controller.CheckIfCountDownElapsed(controller.Data.actionRate))
            {
                // todo: some kind of action 
                Debug.Log("Execute Action! ");
            }
        }
    }
}
