using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endOfDayView()
    {
        FakeCameraEvent.instance.endOfDayView();
    }

    public void startGameView()
    {
        FakeCameraEvent.instance.startGameView();
        
    }

    public void resetQuarterCalendar()
    {
        GameLog.instance.checkForNewQuarter();
    }
}
