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
    public List<action> actions;
    public int threshold,
        thresholdModifier;
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


