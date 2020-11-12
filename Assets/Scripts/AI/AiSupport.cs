using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSupport : MonoBehaviour
{
    public List<EmployeeData> EmployeeAI = new List<EmployeeData>();
    public List<OfficeObject> Interactables = new List<OfficeObject>();

    public Player Player;
    public ProductData ProductData;
    
    private void Awake()
    {
        Player = FindObjectOfType<Player>();
        
    }
    
    public static AiSupport GetSupport(GameObject go)
    {
        return go.GetComponent<AiSupport>();
    }

    public void Refresh()
    {
        //EmployeeAI.Clear();
        Interactables.Clear();
        
        // collect list of employees and interactable objects
        foreach (var o in GetComponents<OfficeObject>())
        {
           Interactables.Add(o);
        }
    }
    
}
