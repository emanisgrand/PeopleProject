using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class OfficeObject : MonoBehaviour
{
   Renderer rend;
   float outlineSize = 0.07f;
   float defaultOutline = 0;
   
   
   private void Awake()
   {
      rend = GetComponent<Renderer>();
   }

   private void Start()
   {
      rend.material.SetFloat("_OutlineThickness", defaultOutline);
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
