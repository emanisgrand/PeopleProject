
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OnScreenCV))]
public class OnScreenCV : MonoBehaviour {
    // listener
 [SerializeField] Text nameText;
 [SerializeField] Text experienceText;
 [SerializeField] Text genderText;
 [SerializeField] Text department;
 
 void Awake()
    {
        Employee.OnEmployeeClicked += OnEmployeeClick;
    }
    
    void OnEmployeeClick(EmployeeData obj)
    {
        nameText.text = obj.name;
        experienceText.text = obj.ExperienceLevel.ToString();
        genderText.text = obj.Gender.ToString();
        department.text = obj.Department.ToString();

        if (!this.gameObject.activeSelf) { this.gameObject.SetActive(true); }
    }
    
    public void ClosePanel() {
        this.gameObject.SetActive(false);
    }
}
