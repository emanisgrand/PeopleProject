using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float Money;
    NavMeshAgent agent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Interaction.OnClick3D += Interaction_OnClick3D;
    }
    
    void Interaction_OnClick3D(Object o) {
        if ( ( (GameObject)o).GetComponent<WalkableFloor>())
        {
            HandlePlayerMovement();
        }
    }

    void HandlePlayerMovement() {
        agent.SetDestination(Interaction.hitPoint);
    }
}
