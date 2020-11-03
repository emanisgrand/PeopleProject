using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    // if not static...
    // Interaction interaction;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Interaction.OnClick3D += Interaction_OnClick3D;
        // if (interaction == null) { interaction = FindObjectOfType<Interaction>(); }
    }
    
    void Interaction_OnClick3D(Object o) {
        Debug.Log("Trying to move: " + o.name);
        if ( ( (GameObject)o).GetComponent<WalkableFloor>())
        {
            HandlePlayerMovement();
        }
    }

    void HandlePlayerMovement() {
        agent.SetDestination(Interaction.hitPoint);
    }
}
