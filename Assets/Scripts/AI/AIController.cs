using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = System.Random;

public class AIController : MonoBehaviour
{
    public string EmployeeName;
    
    public float confusion = 0.3f;
    public float frequency = 1;

    public float waited = 0;

    public List<AiBehavior> Ais=new List<AiBehavior>();

    private EmployeeData employeeData;

    private void Start()
    {
        foreach (var ai in GetComponents<AiBehavior>())
        {
            Ais.Add(ai);
            
            foreach (var e in EmployeeFactory.GetEmployees())
            {
                if (e.name == EmployeeName) employeeData = e;
            }

            gameObject.AddComponent<AiSupport>().name = EmployeeName;
        }
    }

    //test
    private void Update() {
        waited += Time.deltaTime;
        if (waited < frequency) {
            return;
        }

        string aiLog = "";
        float bestAiValue = float.MinValue;
        AiBehavior bestAi = null;
        AiSupport.GetSupport(gameObject).Refresh();
        foreach (var ai in Ais)
        {
            ai.TimePassed += waited;
            var aiValue = ai.GetWeight() * ai.WeightMultiplier + UnityEngine.Random.Range(0,confusion);
            aiLog += ai.GetType().Name + ": " + aiValue + "\n";    
            if (aiValue > bestAiValue) {
                bestAiValue = aiValue;
                bestAi = ai;
            }
        }
        
        Debug.Log(aiLog);
        
        bestAi.Execute();
        waited = 0;
    }
}
