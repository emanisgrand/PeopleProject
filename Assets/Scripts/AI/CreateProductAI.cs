using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo 9-5
public class CreateProductAI : AiBehavior
{
    private AiSupport support = null;
    public float Cost = 200;
    public int PriorityTask = 5;

    public float RangeFromTask = 30;
    public int TriesPerEmployee = 3;

    public GameObject ProductPrefab;

    public override float GetWeight()
    {
        if (support == null) support = AiSupport.GetSupport(gameObject);

        if (support.Player.Money < Cost || support.EmployeeAI.Count == 0) { return 0; }

        if (support.Interactables.Count == 0) return 1;

        // ReSharper disable once PossibleLossOfFraction
        return (support.Interactables.Count / PriorityTask) * support.Player.Money;
    }

    public override void Execute()
    {
        Debug.Log("Executing task");
        var go = Instantiate(ProductPrefab);
        go.AddComponent<Product>().Info = support.ProductData;
    }
}
