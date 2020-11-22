using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="wayPointSystem", menuName="Data/New Waypoint System", order = 52)]
public class WaypointData : ScriptableObject
{
    public static List<AIWaypointNetwork> Waypoints;
}
