
using UnityEngine;
using Object = UnityEngine.Object;

public class Employee : MonoBehaviour
{
    [SerializeField] EmployeeData employeeData;
    
    public static event System.Action<EmployeeData> OnEmployeeClicked;

    void Awake()
    {
        employeeData = EmployeeFactory.GetNextEmployee();
        Interaction.OnClick3D += Interaction_OnClick3D;
    }
    
    public void Interaction_OnClick3D(Object o)
    {
        var emp = ((GameObject) o).GetComponent<Employee>();
        if (emp != null && emp == this)
        {
            OnEmployeeClicked?.Invoke(employeeData);
        } 
    }
}
