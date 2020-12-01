using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

[RequireComponent(typeof(Employee))]
public class StateController : MonoBehaviour {

    public Transform eyes;
    public State remainState;
    public State currentState;
    
    // todo: test if this should be in the employee
    public GameObject gameManager;
    
    
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public float stateTimeElapsed;
    
    [HideInInspector] public EmployeeData Data;
    [HideInInspector] public Transform moveTarget;
    [HideInInspector] public List<Transform> wayPointList;
    
    [HideInInspector] public AIDestinationSetter aiDestination;
    [HideInInspector] public AIPath aiPath;
    private bool aiActive;   

    void Awake ()
    {
        aiPath = GetComponent<AIPath>();  
        Data = GetComponent<Employee>().EmployeeData;
        aiDestination = GetComponent<AIDestinationSetter>();

        // test game manager component 
        if (gameManager != null) { return; } else { Debug.Log("Employee's Game Manager is empty."); }
        
        if (wayPointList == null)
        {
            wayPointList = gameManager.GetComponent<EmployeeFactory>().wayPoints;
        }
    }
    
    
    public void SetupAI(bool aiActivationFromSystem, List<Transform> waypointsInOffice)
    {
        aiActive = aiActivationFromSystem;
        if (aiActive) 
        {
            aiDestination.enabled = true;
        } else 
        {
            aiDestination.enabled = false;
        }
    }

    void Update()
    {
        if (wayPointList != gameManager.GetComponent<EmployeeFactory>().wayPoints)
        {
            Debug.Log("no");
            
        }
        else
        {
//            Debug.Log(wayPointList);
        }
        
        if (!aiActive)
            return;
        currentState.UpdateState (this);
    }

    void OnDrawGizmos()
    {   
        if (currentState != null && eyes != null) 
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, 0.65f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState) 
        {
            currentState = nextState;
            OnExitState ();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
