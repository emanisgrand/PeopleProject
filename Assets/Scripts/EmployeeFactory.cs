using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeFactory : MonoBehaviour
{
   
   public GameObject employeePrefab;
   bool initialized = false;
   int next = 0;
   
   public static EmployeeFactory Instance;
   public EmployeeRoster EmployeeRoster;

   [SerializeField] private List<Transform> spawnPoints;
   
   private void Awake()
   {
      if (Instance != null) { Destroy(this.gameObject); return; } 
      Instance = this;
      DontDestroyOnLoad(this.gameObject);
      Init();
   }

   public static List<EmployeeData> GetEmployees()
   {
      return Instance.EmployeeRoster.Employees;
   }

   public static EmployeeData GetNextEmployee()
   {
      var employee = Instance.EmployeeRoster.Employees[Instance.next];
      Instance.next++;

      if (Instance.next >= Instance.EmployeeRoster.Employees.Count)
      {
         Instance.next = 0;
      }
      
      return employee;
   }
   
   void Init()
   {
      try
      {
         EmployeeRoster = Resources.Load<EmployeeRoster>("employeeRoster");
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         Debug.LogError("Failed to load Employee Roster");
         return;
      }
      
      CreateEmployees(6);
      this.initialized = true;
   }

   public void CreateEmployees(int n)
   {
      for (int i = 0; i < n; i++)
      {
         GameObject obj = Instantiate(employeePrefab);
         obj.transform.position = spawnPoints[i].transform.position;
      } 
   }
}
