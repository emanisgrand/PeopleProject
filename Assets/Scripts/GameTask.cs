using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameTask", menuName = "Data/new Game Task", order = 55)]
public class GameTask : ScriptableObject
{
    SubTask halfHourTask, hourTask;
}

public class SubTask
{
    List<action> actions;
    int threshold,
        thresholdModifier;
}

public class action(){

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


