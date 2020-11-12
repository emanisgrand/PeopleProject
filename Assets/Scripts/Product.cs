using System;
using UnityEngine;
public class Product : MonoBehaviour
{
    public ProductData Info;

    public static ProductData Default;

    private void OnDestroy()
    {
        throw new NotImplementedException();
    }
}
