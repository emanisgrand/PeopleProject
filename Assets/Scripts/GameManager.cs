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

    public GameTask myTime;

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
        } else
        {
            Debug.Log("Failure");
        }


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
        }
        else
        {
            Debug.Log("Failure");
        }


    }
}

[System.Serializable]
public class GameTime
{
    public int minutes,
        hour,
        dayOfWeek,
        week,
        quarter;
}
