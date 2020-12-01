﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // grab the list of time icons
    public GameObject timeIconContainer; //container for the time unit icons
    public List<TimeIcon> timeIcons; //list to store all the time icons in.
    public Slider timeSlider;
    public static UI instance;

    public int[] sliderStepPoints;

    public int timeIconIndex {
        get
        {
            return (timeIcons.Count - GameManager.instance.myTime.timeUnits);
        }
    }
    // when half hour is set
    // consume one unit
    
    // when an hour is set
    // consume two units


    private void Awake()
    {
        instance = this;



        //get the container for the time icons, first child be default.
        timeIconContainer = transform.GetChild(0).gameObject;
        timeIcons = new List<TimeIcon>();

        for(int i = 0; i < timeIconContainer.transform.childCount; i++)
        {
            timeIcons.Add(timeIconContainer.transform.GetChild(i).gameObject.GetComponent<TimeIcon>());
        }
    }

    public void updateTimeIcon(timeUnitCheck.timeUnitStatus status)
    {

        timeIcons[timeIconIndex].updateIcon(status);
    }

    public void updateTimeSlider()
    {
        for(int i = 0; i < sliderStepPoints.Length; i++)
        {
            if(GameManager.instance.myTime.timeUnits > 0 && GameManager.instance.myTime.timeUnits < sliderStepPoints[i])
            {
                timeSlider.value = i;
            } else if (GameManager.instance.myTime.timeUnits <= 0)
            {
                timeSlider.value = sliderStepPoints.Length - 1;
                break;
            }
        }
    }

    void Update()
    {
        updateTimeSlider();
    }
}
