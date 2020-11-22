using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable AI/New Decision/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;
        
        Debug.DrawRay(controller.transform.position, 
            controller.transform.forward.normalized * 5f, Color.green);
            
            // todo: if this works similarly then it should get the v3 from the attached go
            if (Physics.SphereCast(controller.transform.position, 5f, controller.transform.forward,
                out hit, 5f) && hit.collider.GetComponent<OfficeObject>().enabled)
            {
                controller.chaseTarget = hit.transform;
                return true;
            }
            else
            {
                return false;
            }
    }
}
