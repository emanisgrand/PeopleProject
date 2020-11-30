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

    void Start()
    {
        if (instance == null)
            instance = this;
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
                    playerRoll += player.Openness;
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

        if(playerRoll >= threshhold)
        {
            Debug.Log("Success");
            player.MaxFocus += subTask.levelUpStats.Focus;
            player.Commitment += subTask.levelUpStats.Commitment;
            player.Openness += subTask.levelUpStats.Openness;
            player.Respect += subTask.levelUpStats.Respect;
            player.Courage += subTask.levelUpStats.Courage;
            teamStats.documentation += subTask.levelUpTeamStats.documentation;
            teamStats.quality += subTask.levelUpTeamStats.quality;
            teamStats.feedback += subTask.levelUpTeamStats.feedback;
        } else
        {
            Debug.Log("Failure");
            player.MaxFocus -= subTask.levelDownStats.Focus;
            player.Commitment -= subTask.levelDownStats.Commitment;
            player.Openness -= subTask.levelDownStats.Openness;
            player.Respect -= subTask.levelDownStats.Respect;
            player.Courage -= subTask.levelDownStats.Courage;
            teamStats.documentation -= subTask.levelDownTeamStats.documentation;
            teamStats.quality -= subTask.levelDownTeamStats.quality;
            teamStats.feedback -= subTask.levelDownTeamStats.feedback;
        }

        player.Focus--;
        myTime.incMinutes();


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
                    playerRoll += player.Openness;
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

        if (playerRoll >= threshhold)
        {
            Debug.Log("Success");
            player.MaxFocus += subTask.levelUpStats.Focus;
            player.Commitment += subTask.levelUpStats.Commitment;
            player.Openness += subTask.levelUpStats.Openness;
            player.Respect += subTask.levelUpStats.Respect;
            player.Courage += subTask.levelUpStats.Courage;
            teamStats.documentation += subTask.levelUpTeamStats.documentation;
            teamStats.quality += subTask.levelUpTeamStats.quality;
            teamStats.feedback += subTask.levelUpTeamStats.feedback;
        }
        else
        {
            Debug.Log("Failure");
            player.MaxFocus -= subTask.levelDownStats.Focus;
            player.Commitment -= subTask.levelDownStats.Commitment;
            player.Openness -= subTask.levelDownStats.Openness;
            player.Respect -= subTask.levelDownStats.Respect;
            player.Courage -= subTask.levelDownStats.Courage;
            teamStats.documentation -= subTask.levelDownTeamStats.documentation;
            teamStats.quality -= subTask.levelDownTeamStats.quality;
            teamStats.feedback -= subTask.levelDownTeamStats.feedback;
        }

        player.Focus -= 2;
        myTime.incHour();

    }
}

[System.Serializable]
public class GameTime
{

    //main time tracking variables
    [Header("Game Time")]
    public int minutes;
        public int hour,
        dayOfWeek,
        week,
        quarter;

    [Header("Extra Settings")]
    //increase minutes by how much?
    public int minuteIncrease = 30;

    //main time limits
    public int lastMinute,
        startHour,
        lastHour,
        lastDayOfWeek,
        lastWeek,
        lastQuarter;

    public void incMinutes()
    {
        minutes += minuteIncrease;

        if(minutes < lastMinute)
        {
            minutes = 0;
            incHour();
        }
    }

    public void incHour()
    {
        if(hour < lastHour)
        {
            hour += 1;
        } else
        {
            hour = startHour;
            incDay();
            minutes = 0;
        }
    }

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
