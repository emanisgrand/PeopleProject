using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "GameTask", menuName = "Data/New Game Task", order = 55)]
public class GameTask : ScriptableObject
{
    public SubTask halfHourTask, hourTask;
}

[System.Serializable]
public class SubTask
{
    public List<action> actions; //list of actions for the roll
    public int threshold, //threshold for the player roll to reach
        thresholdModifier; //a modifier that will add a random value between 0 and thresholdModifier.
    public basicStats levelUpStats = new basicStats(0, 0, 0, 0, 0), //stats used to increase player scores
        levelDownStats = new basicStats(0, 0, 0, 0, 0); //stats used to decrease player scores
    public TeamStats levelUpTeamStats, levelDownTeamStats; //team stats for increasing and decreasing, same as player
    //minimum and maximum focus cost to the player, and a extra penelty to focus if they fail
    public float focusCostMin, focusCostMax, focusPenalty;
    //will this add to focus instead?
    public bool addToFocus;
}

[System.Serializable]
public class action{

    public enum ActionType
    {
        playerAction,
        teamAction
    };

    public enum PlayerAction
    {
        Focus,
        Commitment,
        Openness,
        Respect,
        Courage
    };

    public enum TeamAction
    {
        Documentation,
        Quality,
        Feedback
    };

public ActionType actionType;
public PlayerAction playerAction;
public TeamAction teamAction;

}




