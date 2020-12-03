using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //reference to the main stats panel
    public GameObject gameStatsPanel;
    public GameObject timeBarObject;
    public GameObject Moon;
    public GameObject Calendar;

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

    [Header("Calendar References")]
    public List<GameObject> weeksInCalendar;
    [SerializeField]
    public List<List<GameObject>> daysInCalendar;
    [SerializeField]
    public List<List<Text>> checksInCalendar;


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

        Calendar = GameObject.Find("Calendar");
        gameStatsPanel = GameObject.Find("GameStatsPanel");

        if(Calendar != null)
        {

            daysInCalendar = new List<List<GameObject>>();
            checksInCalendar = new List<List<Text>>();
            for(int y = 0; y < Calendar.transform.childCount; y++)
            {
                weeksInCalendar.Add(Calendar.transform.GetChild(y).gameObject);
                daysInCalendar.Add(new List<GameObject>());
                checksInCalendar.Add(new List<Text>());
                for(int x = 0; x < weeksInCalendar[weeksInCalendar.Count-1].transform.childCount; x++)
                {
                    daysInCalendar[y].Add(weeksInCalendar[weeksInCalendar.Count - 1].transform.GetChild(x).gameObject);
                    checksInCalendar[y].Add(weeksInCalendar[weeksInCalendar.Count - 1].transform.GetChild(x).gameObject.GetComponentInChildren<Text>());
                }
            }
        }

        initCalendar();
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
        courageText.text = GameManager.instance.player.CourageLevel.ToString();
        commitmentText.text = GameManager.instance.player.CommitmentLevel.ToString();
        transparencyText.text = GameManager.instance.player.TransparencyLevel.ToString();
        respectText.text = GameManager.instance.player.RespectLevel.ToString();
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

    public void initCalendar()
    {
        for(int y = 0; y < daysInCalendar.Count; y++)
        {
            for(int x = 0; x < daysInCalendar[y].Count; x++)
            {
                checksInCalendar[y][x].text = "-";
            }
        }
    }

    public void updateCalendar()
    {
        for (int y = 0; y < GameLog.instance.currentQuarter.myWeeks.Count; y++)
        {
            weekCheck myWeek = GameLog.instance.currentQuarter.myWeeks[y];
            for (int x = 0; x < myWeek.myDays.Count; x++)
            {
                dayCheck myDay = myWeek.myDays[x];

                if (myDay.myStatus == dayCheck.dayStatus.success)
                {
                    checksInCalendar[y][x].text = "o";
                    checksInCalendar[y][x].color = Color.green;
                } else if(myDay.myStatus == dayCheck.dayStatus.failure)
                {
                    checksInCalendar[y][x].text = "x";
                    checksInCalendar[y][x].color = Color.red;
                }
            }
        }
    }
}
