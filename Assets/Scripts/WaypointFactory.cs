using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFactory : MonoBehaviour
{
    public GameObject waypointPrefab;
    private bool initialized = false;

    private AIWaypointNetwork aiWaypointNetwork;
    public List<AIWaypointNetwork> GeneratedWaypoints;
    
    public static WaypointFactory Instance;
    public WaypointData WaypointData;
    
    private void Awake()
    {
        if (Instance != null) {Destroy(this.gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }
    

    void Init()
    {
        try
        {
            WaypointData = Resources.Load<WaypointData>("waypointData");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debug.LogError("Failed to load Waypoint Data");
            return;
        }
    }

    
}
