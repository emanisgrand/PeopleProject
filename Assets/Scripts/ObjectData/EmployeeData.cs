using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "employeedata", menuName = "Data/New Employee Data", order=51)]
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

    // radius for looksphere gizmo
    public float lookSphereCastRadius = 2f;

    // AI: vision distance
    public float visionDistance = 2f;
    
    // AI: actionRate
    public float actionRate = 0.5f;
    
    // npc STAT: focus
    public float statFocus = 100;
    
    // how long it takes for the npc to turn
    public float turnSpeed = 30;
    
    // how long it takes to get to a task.
    public float searchDuration = 20f;
    
    // employee name
    public string EmployeeName;
    
    public DEPARTMENT Department;
    public EXPERIENCE_LEVEL ExperienceLevel;
    public PRESENTS_AS Gender;
    
    // image
    // public Sprite Icon;
    // todo: hat section
}
