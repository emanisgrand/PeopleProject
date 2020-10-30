using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour {
    
    public EmployeeData m_employeeData;
    
    public static event System.Action<EmployeeData> OnEmployeeClicked;
    
    private void Awake()
    {
        Interaction.OnClick3D += Interaction_OnClick3D;
    }

    private void Interaction_OnClick3D(Object o)
    {
        if (((GameObject) o).GetComponent<Employee>() != null)
        {
            OnEmployeeClicked?.Invoke(m_employeeData);
        } 
    }
}
