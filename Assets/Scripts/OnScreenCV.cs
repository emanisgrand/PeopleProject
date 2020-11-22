
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OnScreenCV))]
public class OnScreenCV : MonoBehaviour {
    // listener
 [SerializeField] Text nameText;
 [SerializeField] Text experienceText;
 [SerializeField] Text genderText;
 [SerializeField] Text department;
 [SerializeField] Text focusText;
 
 void Awake()
    {
        Employee.OnEmployeeClicked += OnEmployeeClick;
    }
    
    void OnEmployeeClick(EmployeeData obj)
    {
        nameText.text = "name: " + obj.name.ToString();
        experienceText.text = "xp lvl: " + obj.ExperienceLevel.ToString();
        genderText.text = "presents as: " + obj.Gender.ToString();
        department.text = "dept: " + obj.Department.ToString();
        focusText.text = "focus: " + obj.statFocus.ToString(CultureInfo.CurrentCulture);

        if (!this.gameObject.activeSelf) { this.gameObject.SetActive(true); }
    }
    
    public void ClosePanel() {
        this.gameObject.SetActive(false);
    }
}
