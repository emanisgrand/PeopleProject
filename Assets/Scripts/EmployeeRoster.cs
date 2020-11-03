using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "employeeRoster", menuName = "Employee Roster", order = 52)]
public class EmployeeRoster : ScriptableObject
{
    public List<EmployeeData> Employees;
}
