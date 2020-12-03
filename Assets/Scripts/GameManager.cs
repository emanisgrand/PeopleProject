using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public TeamStats teamStats;
    public GameTask myTask;

    public GameTime myTime = new GameTime();

    public static GameManager instance;

    public List<TimeIcon> timeIcons;
    public List<Transform> OfficeWayPoints;
    public float gamePercentage,
        currentPercentage,
        quarterPercentage,
        weekPercentage,
        dayPercentage;

    public Animator fadeCanvasAnim;

    public bool endOfDay;
    private void Awake()
    {
        
    }

    void Start()
    {
        if (instance == null)
            instance = this;

        fadeCanvasAnim = GameObject.Find("FadeCanvas").GetComponent<Animator>();
    }

    public void doHalfHourTask()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        SubTask subTask = myTask.halfHourTask;

        int threshhold = subTask.threshold + Random.Range(0, subTask.thresholdModifier);

        int playerRoll = Random.Range(0, 21);

        List<action> actions = subTask.actions;

        for(int i = 0; i < actions.Count; i++)
        {
            if(actions[i].actionType == action.ActionType.playerAction)
            {
                if (actions[i].playerAction == action.PlayerAction.Focus)
                    playerRoll += player.Focus;
                else if (actions[i].playerAction == action.PlayerAction.Commitment)
                    playerRoll += player.Commitment;
                else if (actions[i].playerAction == action.PlayerAction.Openness)
                    playerRoll += player.Transparency;
                else if (actions[i].playerAction == action.PlayerAction.Respect)
                    playerRoll += player.Respect;
                else if (actions[i].playerAction == action.PlayerAction.Courage)
                    playerRoll += player.Courage;

            } else if (actions[i].actionType == action.ActionType.teamAction)
            {
                if (actions[i].teamAction == action.TeamAction.Documentation)
                    playerRoll += teamStats.documentation;
                else if (actions[i].teamAction == action.TeamAction.Quality)
                    playerRoll += teamStats.quality;
                else if (actions[i].teamAction == action.TeamAction.Feedback)
                    playerRoll += teamStats.feedback;
            }
        }

        timeUnitCheck timeCheck = new timeUnitCheck(timeUnitCheck.timeUnitStatus.none);

        if(playerRoll >= threshhold)
        {
            Debug.Log("Success: " + playerRoll);
            player.Focus += subTask.levelUpStats.Focus;
            player.Commitment += subTask.levelUpStats.Commitment;
            player.Transparency += subTask.levelUpStats.Transparency;
            player.Respect += subTask.levelUpStats.Respect;
            player.Courage += subTask.levelUpStats.Courage;
            teamStats.documentation += subTask.levelUpTeamStats.documentation;
            teamStats.quality += subTask.levelUpTeamStats.quality;
            teamStats.feedback += subTask.levelUpTeamStats.feedback;
            timeCheck.myStatus = timeUnitCheck.timeUnitStatus.success;
        } else {
            Debug.Log("Failure " + playerRoll);
            player.Focus -= subTask.levelDownStats.Focus;
            player.Commitment -= subTask.levelDownStats.Commitment;
            player.Transparency -= subTask.levelDownStats.Transparency;
            player.Respect -= subTask.levelDownStats.Respect;
            player.Courage -= subTask.levelDownStats.Courage;
            teamStats.documentation -= subTask.levelDownTeamStats.documentation;
            teamStats.quality -= subTask.levelDownTeamStats.quality;
            teamStats.feedback -= subTask.levelDownTeamStats.feedback;
            timeCheck.myStatus = timeUnitCheck.timeUnitStatus.failure;
        }

        timeCheck.myTaskAction = myTask.myTaskAction;
        timeCheck.myTaskObject = myTask.myTaskObject;

        GameLog.instance.insertTimeUnit(timeCheck);

        if (subTask.addToFocus)
            player.incFocus(subTask.focusCostMin, subTask.focusCostMax);
        else
            player.decFocus(subTask.focusCostMin, subTask.focusCostMax);

        myTime.decTimeUnit(timeCheck);


    }

    public void doHourTask()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        SubTask subTask = myTask.hourTask;

        int threshhold = subTask.threshold + Random.Range(0, subTask.thresholdModifier);

        int playerRoll = Random.Range(0, 21);

        List<action> actions = subTask.actions;

        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].actionType == action.ActionType.playerAction)
            {
                if (actions[i].playerAction == action.PlayerAction.Focus)
                    playerRoll += player.Focus;
                else if (actions[i].playerAction == action.PlayerAction.Commitment)
                    playerRoll += player.Commitment;
                else if (actions[i].playerAction == action.PlayerAction.Openness)
                    playerRoll += player.Transparency;
                else if (actions[i].playerAction == action.PlayerAction.Respect)
                    playerRoll += player.Respect;
                else if (actions[i].playerAction == action.PlayerAction.Courage)
                    playerRoll += player.Courage;

            }
            else if (actions[i].actionType == action.ActionType.teamAction)
            {
                if (actions[i].teamAction == action.TeamAction.Documentation)
                    playerRoll += teamStats.documentation;
                else if (actions[i].teamAction == action.TeamAction.Quality)
                    playerRoll += teamStats.quality;
                else if (actions[i].teamAction == action.TeamAction.Feedback)
                    playerRoll += teamStats.feedback;
            }
        }

        timeUnitCheck timeCheck = new timeUnitCheck(timeUnitCheck.timeUnitStatus.none);

        if (playerRoll >= threshhold)
        {
            Debug.Log("Success: " + playerRoll);
            player.Focus += subTask.levelUpStats.Focus;
            player.Commitment += subTask.levelUpStats.Commitment;
            player.Transparency += subTask.levelUpStats.Transparency;
            player.Respect += subTask.levelUpStats.Respect;
            player.Courage += subTask.levelUpStats.Courage;
            teamStats.documentation += subTask.levelUpTeamStats.documentation;
            teamStats.quality += subTask.levelUpTeamStats.quality;
            teamStats.feedback += subTask.levelUpTeamStats.feedback;
            timeCheck.myStatus = timeUnitCheck.timeUnitStatus.success;
        }
        else
        {
            Debug.Log("Failure: " + playerRoll);
            player.Focus -= subTask.levelDownStats.Focus;
            player.Commitment -= subTask.levelDownStats.Commitment;
            player.Transparency -= subTask.levelDownStats.Transparency;
            player.Respect -= subTask.levelDownStats.Respect;
            player.Courage -= subTask.levelDownStats.Courage;
            teamStats.documentation -= subTask.levelDownTeamStats.documentation;
            teamStats.quality -= subTask.levelDownTeamStats.quality;
            teamStats.feedback -= subTask.levelDownTeamStats.feedback;
            timeCheck.myStatus = timeUnitCheck.timeUnitStatus.failure;
            player.CurrentFocus -= subTask.focusPenalty;
        }

        timeCheck.myTaskAction = myTask.myTaskAction;
        timeCheck.myTaskObject = myTask.myTaskObject;

        GameLog.instance.currentDay.myTimeUnits.Add(timeCheck);
        GameLog.instance.currentDay.myTimeUnits.Add(timeCheck);

        if (subTask.addToFocus)
            player.incFocus(subTask.focusCostMin, subTask.focusCostMax);
        else
            player.decFocus(subTask.focusCostMin, subTask.focusCostMax);

        myTime.decTwoTimeUnits(timeCheck);

    }

    void Update()
    {
        gamePercentage = myTime.gamePercentage;
        currentPercentage = myTime.currentGamePercentage;
        quarterPercentage = myTime.quarterPercentage;
        weekPercentage = myTime.weekPercentage;
        dayPercentage = myTime.dayPercentage;

        if(myTime.timeUnits <= 0 && !endOfDay)
        {
            endOfDay = true;
            Invoke("endOfDayView", 1f);
        }
    }

    public void endOfDayView()
    {
        fadeCanvasAnim.Play("FadeCanvasEnd");
    }

    public void startGameView()
    {
        fadeCanvasAnim.Play("FadeCanvasGame");
    }
}



//Main class for keeping track of current game time.
[System.Serializable]
public class GameTime 
{
    //main time tracking variables
    [Header("Game Time")]
    public int timeUnits = 16;
        public int dayOfWeek,
        week,
        quarter;

    [Header("Extra Settings")]
    //increase minutes by how much?
    public int minuteIncrease = 30;

    //main time limits
    public int startUnits,    //the amount of time units at the beginning of the day.
        lastDayOfWeek,        //when's the last day of the week?
        lastWeek,             //when's the last week of the quarter?
        lastQuarter;          //when's the final quarter?

    public float currentGamePercentage
    {
        get
        {
            return gamePercentage == 100f ? gamePercentage : gamePercentage + quarterPercentage + weekPercentage + dayPercentage;
        }
    }

    public float gamePercentage
    {
        get
        {
            return ((float)(quarter-1) / (float)lastQuarter) * 100;
        }
    }

    public float quarterPercentage
    {
        get
        {
            return ((float)(week-1) / (float)lastWeek) * 25f;
        }
    }

    public float weekPercentage
    {
        get
        {
            return ((float)(dayOfWeek - 1) / (float)lastDayOfWeek) * 6.25f;
        }
    }

    public float dayPercentage
    {
        get
        {
            return ((float)(startUnits - timeUnits) / (float)startUnits) * 1.25f;
        }
    }

    //main function for decreasing current time units.
    public void decTimeUnit(timeUnitCheck status)
    {

        UI.instance.updateTimeIcon(status.myStatus);

        timeUnits -= 1;

        if (timeUnits < 1)
        {
            timeUnits = 0;
            incDay();
        }
    }

    public void decTwoTimeUnits( timeUnitCheck status)
    {

        UI.instance.updateTimeIcon(status.myStatus);

        timeUnits -= 1;

        UI.instance.updateTimeIcon(status.myStatus);

        timeUnits -= 1;

        if (timeUnits < 1)
        {
            timeUnits = 0;
            incDay();
        }
    }

    
    //main function for increasing the day of the week.
    public void incDay()
    {
        if(dayOfWeek < lastDayOfWeek)
        {
            dayOfWeek += 1;
        } else
        {
            dayOfWeek = 1;
            incWeek();
        }
    }

    //main function for increasing week of the current quarter.
    public void incWeek()
    {
        if(week < lastWeek)
        {
            week += 1; 
        } else
        {
            week = 1;
            incQuarter();
        }
    }

    //function for increasing the quarter.
    public void incQuarter()
    {
        if (quarter < lastQuarter)
        {
            quarter += 1;
        } else
        {
            //game finished, ending goes here.
        }
    }
}


//main classes for checking success or failure
//in certain all units of time.
[System.Serializable]
public class timeUnitCheck
{
    public enum timeUnitStatus
    {
        none,
        success,
        failure
    };

    public timeUnitCheck(timeUnitCheck.timeUnitStatus status)
    {
        myStatus = status;
    }

    public GameTask.taskAction myTaskAction;
    public GameTask.taskObject myTaskObject;

    public timeUnitStatus myStatus;
}

[System.Serializable]
public class dayCheck
{
    public enum dayStatus
    {
        none,
        success,
        failure
    }

    public dayStatus myStatus;
    public List<timeUnitCheck> myTimeUnits;

    public dayCheck()
    {
        myTimeUnits = new List<timeUnitCheck>();
    }
}

[System.Serializable]
public class weekCheck
{
    public enum weekStatus
    {
        none, success, failure
    };

    public weekStatus myStatus;
    public List<dayCheck> myDays;

    public weekCheck()
    {
        myDays = new List<dayCheck>();
    }
}

[System.Serializable]
public class quarterCheck
{
    public enum quarterStatus
    {
        none, success, failure
    };

    public quarterStatus myStatus;
    public List<weekCheck> myWeeks;

    public quarterCheck()
    {
        myWeeks = new List<weekCheck>();
    }

    
}
