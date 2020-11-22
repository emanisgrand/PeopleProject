using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable AI/New Decision/Scan")]
public class ScanDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool noEnemyInSight = Scan(controller);
        return noEnemyInSight;
    }

    private bool Scan(StateController controller)
    {
        controller.navMeshAgent.Stop();
        controller.transform.Rotate(0, controller.employee.EmployeeData.turnSpeed * Time.deltaTime, 0);
        return controller.CheckIfCountDownElapsed(controller.employee.EmployeeData.searchDuration);
    }
}
