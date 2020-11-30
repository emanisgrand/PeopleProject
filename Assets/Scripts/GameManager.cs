using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public TeamStats teamStats;
    public GameTask myTask;

    public static GameManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void doHalfHourTask()
    {
        Random.initState((int)System.DateTime.Now.Ticks);

        SubTask subTask = myTask.halfHourTask;

        int threshhold = subTask.threshold + Random.Range(0, subTask.thresholdModifier);

        int playerRoll = Random.Range(0, 21);

        List<action> actions = subTask.actions;

        for(int i = 0; i < actions.Count; i++)
        {
            if(actions[i].actionType == ActionType.playerAction)
            {
                if (actions[i].playerAction == PlayerAction.Focus)
                    playerRoll += player.Focus;
                else if (actions[i].playerAction == PlayerAction.Commitment)
                    playerRoll += player.Commitment;
                else if (actions[i].playerAction == PlayerAction.Openness)
                    playerRoll += player.Openness;
                else if (actions[i].playerAction == PlayerAction.Respect)
                    playerRoll += player.Respect;
                else if (actions[i].playerAction == PlayerAction.Courage)
                    playerRoll += player.Courage;

            } else if (actions[i].actionType == ActionType.teamAction)
            {
                if (actions[i].teamAction == TeamAction.Documentation)
                    playerRoll += teamStats.Documentation;
                else if (actions[i].teamAction == TeamAction.Quality)
                    playerRoll += teamStats.Quality;
                else if (actions[i].teamAction == TeamAction.Feedback)
                    playerRoll += teamStats.Feedback;
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
        Random.initState((int)System.DateTime.Now.Ticks);

        SubTask subTask = myTask.hourTask;

        int threshhold = subTask.threshold + Random.Range(0, subTask.thresholdModifier);

        int playerRoll = Random.Range(0, 21);

        List<action> actions = subTask.actions;

        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].actionType == ActionType.playerAction)
            {
                if (actions[i].playerAction == PlayerAction.Focus)
                    playerRoll += player.Focus;
                else if (actions[i].playerAction == PlayerAction.Commitment)
                    playerRoll += player.Commitment;
                else if (actions[i].playerAction == PlayerAction.Openness)
                    playerRoll += player.Openness;
                else if (actions[i].playerAction == PlayerAction.Respect)
                    playerRoll += player.Respect;
                else if (actions[i].playerAction == PlayerAction.Courage)
                    playerRoll += player.Courage;

            }
            else if (actions[i].actionType == ActionType.teamAction)
            {
                if (actions[i].teamAction == TeamAction.Documentation)
                    playerRoll += teamStats.Documentation;
                else if (actions[i].teamAction == TeamAction.Quality)
                    playerRoll += teamStats.Quality;
                else if (actions[i].teamAction == TeamAction.Feedback)
                    playerRoll += teamStats.Feedback;
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
