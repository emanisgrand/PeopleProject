using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel_IO : MonoBehaviour
{
    public GameObject skillTreePanel;
    private bool isPanelClosed;

    private void Awake()
    {
        skillTreePanel = GetComponent<RectTransform>().gameObject;
    }

    public void OpenSkillTreePanel()
    {
        if (isPanelClosed)
        skillTreePanel.SetActive(true);
        isPanelClosed = false;
    }

    public void CloseSkillTreePanel()
    {
        if (isPanelClosed)
        {
            skillTreePanel.SetActive(false);
        }
    }
    
}
