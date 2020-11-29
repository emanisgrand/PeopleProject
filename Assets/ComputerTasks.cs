using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTasks : MonoBehaviour
{
    [SerializeField]
    public List<GameTask> documentTasks,
        callMeetingTasks,
        evaluateSelfTasks,
        evaluatePromptedTasks,
        evaluateUnpromptedTasks;

    private int documentIndex,
        callIndex,
        evaluateSelfIndex,
        evaluatePromptedIndex,
        evaluateUnpromptedIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void documentation()
    {
 //       GameManager.instance.myTask = documentTasks[documentIndex];

        if (documentIndex < documentTasks.Count - 1)
            documentIndex++;
        else
            documentIndex = 0;
    }

    public void callMeeting()
    {
 //       GameManager.instance.myTask = callMeetingTasks[callIndex];
        callIndex++;
    }

    public void evaluateSelf()
    {
//        GameManager.instance.myTask = evaluateSelfTasks[evaluateSelfIndex];
        evaluateSelfIndex++;
    }

    public void evaluatePrompted()
    {
//        GameManager.instance.myTask = evaluatePromptedTasks[evaluatePromptedIndex];
        evaluatePromptedIndex++;
    }

    public void evaluateUnprompted()
    {
//        GameManager.instance.myTask = evaluateUnpromptedTasks[evaluateUnpromptedIndex];
        evaluateUnpromptedIndex++;
    }
}
