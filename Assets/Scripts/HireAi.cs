using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HireAi : AiBehavior
{
    public int HeadCount = 5;
    public float Cost = 50;
    private AiSupport support;

    public override float GetWeight()
    {
        if (support == null) support = AiSupport.GetSupport(gameObject);

        if (support.Player.Money < Cost) return 0;

        var currentHeadCount = support.EmployeeAI.Count;
        var tasks = support.Interactables.Count;

        if (support.ProductData.QualityScore * support.EmployeeAI.Count <= support.Interactables.Count)
            return 1;

        return 0;
    }

    public override void Execute()
    {
        Debug.Log(support.Player.name + " has been onboarded!");
        var tasks = support.Interactables;
        var index = UnityEngine.Random.Range(0, tasks.Count);
        var taskList = tasks[index];
    }
}
