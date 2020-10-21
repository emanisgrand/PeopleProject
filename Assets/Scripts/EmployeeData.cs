using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeData : ScriptableObject {
    public enum EXPERIENCE_LEVEL { 
        unknown, 
        Junior,
        Lead,
        Senior
    }

    [SerializeField] string _employeeName;
    public string EmployeeName => _employeeName;
    
    [SerializeField] EXPERIENCE_LEVEL _experienceLevelLevel;
    public EXPERIENCE_LEVEL ExperienceLevel => _experienceLevelLevel;
    
    // presenting
    [SerializeField] Texture _icon;
    public Texture Icon => _icon;


}
