using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class OfficeObject : MonoBehaviour
{
   Renderer rend;
   float outlineSize = 0.07f;
   float defaultOutline = 0;
    public GameObject myCanvas, taskPanel, subTaskPanel;
    public bool showingWindow;
   
   private void Awake()
   {
      rend = GetComponent<Renderer>();
        if (transform.childCount > 0)
        {
            
            myCanvas = transform.GetChild(0).gameObject;
            taskPanel = myCanvas.transform.GetChild(0).gameObject;
            subTaskPanel = myCanvas.transform.GetChild(1).gameObject;
            showingWindow = myCanvas.transform.gameObject.activeInHierarchy;
        }
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

    private void OnMouseDown()
    {
        showingWindow = !showingWindow;
        setCanvasActive(showingWindow);

        if (!showingWindow)
        {
            setTaskPanel(false);
        }
    }

    public void setTaskPanel(bool subTask = false)
    {
        if (subTask)
        {
            subTaskPanel.SetActive(true);
            taskPanel.SetActive(false);
        } else
        {
            subTaskPanel.SetActive(false);
            taskPanel.SetActive(true);
        }
    }

    public void setCanvasActive(bool setting)
    {
        myCanvas.SetActive(setting);
        showingWindow = setting;
    }
}
