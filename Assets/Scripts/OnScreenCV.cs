using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OnScreenCV))]
public class OnScreenCV : MonoBehaviour
{ 
 [SerializeField] Text nameText;
 [SerializeField] Text experienceText;
 [SerializeField] Text genderText;
 [SerializeField] Text department;

 private void Awake()
    {
     Employee.OnEmployeeClicked += OnEmployeeClicked;
        
    }

    private void OnEmployeeClicked(EmployeeData obj)
    {
        
        nameText.text = obj.name;
        experienceText.text = obj.ExperienceLevel.ToString();
        genderText.text = obj.Gender.ToString();
        department.text = obj.Department.ToString();
        this.gameObject.SetActive(true);
    }
    
    public void ClosePanel() {
        this.gameObject.SetActive(false);
    }
}
