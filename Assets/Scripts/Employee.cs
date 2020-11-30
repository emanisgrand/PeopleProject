
using UnityEngine;
using Object = UnityEngine.Object;

public class Employee : MonoBehaviour
{
    public GameObject myCanvas, taskPanel, subTaskPanel;
    [SerializeField] private EmployeeData employeeData;
    public EmployeeData EmployeeData => employeeData;

   public static event System.Action<EmployeeData> OnEmployeeClicked;

    void Awake()
    {
        //todo: 1. get the UI panel from OnScreenCV

        employeeData = EmployeeFactory.GetNextEmployee();
        gameObject.name = employeeData.name;
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
