
using System.Globalization;
using DG.Tweening;
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

 [SerializeField] GameObject panel;
 
 
 void Awake()
    {
        Employee.OnEmployeeClicked += OnEmployeeClick;
    }
    
    void OnEmployeeClick(EmployeeData obj)
    {
        nameText.text = "name: " + obj.name.ToString();
        experienceText.text = "Exp: " + obj.ExperienceLevel.ToString();
        genderText.text = "Presents: " + obj.Gender.ToString();
        department.text = "Dept: " + obj.Department.ToString();
        focusText.text = "Focus: " + obj.statFocus.ToString(CultureInfo.CurrentCulture);

        if (!panel.activeSelf) { 
            panel.SetActive(true);
        }    
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
