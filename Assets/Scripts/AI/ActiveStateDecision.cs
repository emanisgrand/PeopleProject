using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable AI/New Decision/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        // deactivate if already in use.
        bool chaseTargetIsActive = controller.moveTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
    }
}
