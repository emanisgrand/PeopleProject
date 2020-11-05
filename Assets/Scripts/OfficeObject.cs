using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class OfficeObject : MonoBehaviour
{
   Renderer rend;
   float outlineSize = 1.08f;
   float defaultOutline = 1;
   
   private void Awake()
   {
      rend = GetComponent<Renderer>();
   }
   
   private void OnMouseEnter()
   {
      rend.material.SetFloat("_OutlineThickness", outlineSize);
   }
   
   private void OnMouseExit()
   {
      rend.material.SetFloat("_OutlineThickness", defaultOutline);
   }
}
