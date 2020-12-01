using UnityEngine;

namespace AI {
[CreateAssetMenu(menuName = "Scriptable AI/New Action/Walkabout")]
    public class WalkaboutAction : Action
    {
        private GameManager _gameManager;
        public override void Act(StateController controller)
    {
        Walk(controller);
    }

    private void Walk(StateController controller)
    {
        Debug.Log("walk action happening.");
        _gameManager = GameManager.instance;

        // this is only a test.
        controller.aiDestination.target =
            _gameManager.GetComponent<EmployeeFactory>().wayPoints[controller.nextWayPoint];
        
        
        if (controller.wayPointList != null)
        {
            controller.aiDestination.target = controller.wayPointList[controller.nextWayPoint];
        }
        else
        {
            Debug.Log("Waypoints empty. Check reference.");
        }
        
            
        if (controller.aiPath.remainingDistance <= 
            controller.aiPath.endReachedDistance && !controller.aiPath.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.aiDestination.target = controller.wayPointList[controller.nextWayPoint];
        }
        
    }
}
}
