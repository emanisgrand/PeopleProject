using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "employeedata", menuName = "Employee Data", order=51)]
public class EmployeeData : ScriptableObject {
    public enum DEPARTMENT {
        Unknown,
        Engineering,
        Operations,
        CSuite,
        QualityAssurance
    }

    public enum EXPERIENCE_LEVEL { 
        Unknown, 
        Junior,
        Lead,
        Senior
    }
    public enum PRESENTS_AS {
        Unknown,
        Cisgender,
        Transgender,
        TwoSpirit,
        NonBinary,
        Genderqueer,
        GenderExpressive,
        GenderFluid,
        GenderNeutral
    }
    
    // employee name
    public string EmployeeName;
    // department
    public DEPARTMENT Department;
    // experience level
    public EXPERIENCE_LEVEL ExperienceLevel;
    // gender
    public PRESENTS_AS Gender;
    // image
    // public Sprite Icon;
    // todo: hat section
}
