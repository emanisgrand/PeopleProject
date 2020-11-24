using UnityEngine;
using System.Collections.Generic;
public class ComponentSorter : MonoBehaviour
{
    [HideInInspector]
    public List<Component> components;
    void OnGUI()
    {
        for (int i = 0; i < components.Count; i++) {
            GUI.Label(new Rect(Screen.width / 2, i * 25, 500, 50), components[i].ToString());
        }
    }
}