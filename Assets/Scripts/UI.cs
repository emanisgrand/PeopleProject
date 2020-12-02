using System;
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

    //player stats text
    [Header("Player Stats Text")]
    public Text courageText;
    public Text commitmentText,
        transparencyText,
        respectText;

    //focus slider
    [Header("Focus Slider")]
    public Slider focusSlider;

    //team stats text
    [Header("Team Stats Text")]
    public Text feedbackText;
    public Text qualityText,
        documentationText;


    public Image moonImage;

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
        timeSlider.value = timeIconIndex;
    }

    public void updatePlayerStatsText()
    {
        Debug.Log(GameManager.instance.player.focusPercentage);
        focusSlider.value = 100 - GameManager.instance.player.focusPercentage;
        courageText.text = GameManager.instance.player.Courage.ToString();
        commitmentText.text = GameManager.instance.player.Commitment.ToString();
        transparencyText.text = GameManager.instance.player.Transparency.ToString();
        respectText.text = GameManager.instance.player.Respect.ToString();
    }

    public void updateTeamStatsText()
    {
        feedbackText.text = GameManager.instance.teamStats.feedback.ToString();
        qualityText.text = GameManager.instance.teamStats.quality.ToString();
        documentationText.text = GameManager.instance.teamStats.documentation.ToString();
    }

    void Update()
    {
        updateTimeSlider();
        updatePlayerStatsText();
        updateTeamStatsText();
        updateMoonImage();
    }

    public void updateMoonImage()
    {
        moonImage.fillAmount = GameManager.instance.currentPercentage / 100;
    }
}
