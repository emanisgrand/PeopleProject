using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Interaction : MonoBehaviour
{
    public static Vector3 hitPoint;
    public static event System.Action<Object> OnClick3D;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { Interact(); }
    }
    
    private void Interact() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        bool hasHit = Physics.Raycast(ray, out hit);
        
        if (hit.collider!=null)
        {
            hitPoint = hit.point;
            
            // signal out what has been hit
            OnClick3D?.Invoke(hit.collider.gameObject);
        }
    }
}
