using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Employee))]
public class StateController : MonoBehaviour {

    public Transform eyes;
    public State remainState;
    public State currentState;
    public GameObject gameManager;
    
    [HideInInspector] public AIPath aiPath;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public EmployeeData Data;
    [HideInInspector] public Transform moveTarget;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public AIDestinationSetter aiDestination;
    
    private bool aiActive;   

    void Awake ()
    {
        aiPath = GetComponent<AIPath>();  
        Data = GetComponent<Employee>().EmployeeData;
        aiDestination = GetComponent<AIDestinationSetter>();
        wayPointList = gameManager.GetComponent<EmployeeFactory>().wayPoints;
    }
    
    public void SetupAI(bool aiActivationFromSystem, List<Transform> waypointsInOffice)
    {
        //wayPointList = waypointsInOffice;
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