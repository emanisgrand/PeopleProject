using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog : MonoBehaviour
{

    public dayCheck currentDay;
    public quarterCheck currentQuarter;
    public List<quarterCheck> myQuarters;

    public static GameLog instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myQuarters = new List<quarterCheck>();
        currentDay = new dayCheck();
        currentQuarter = new quarterCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void insertQuarterUnit()
    {
        GameTime myTime = GameManager.instance.myTime;
        myQuarters.Add(currentQuarter);
    }

    public void insertWeekUnit()
    {
        GameTime myTime = GameManager.instance.myTime;
        currentQuarter.myWeeks.Add(new weekCheck());

        if (currentQuarter.myWeeks.Count >= myTime.lastWeek)
        {
            insertQuarterUnit();

            
        }
    }

    public void checkForNewQuarter()
    {
        if (currentQuarter.myWeeks.Count == GameManager.instance.myTime.lastWeek &&
                currentQuarter.myWeeks[GameManager.instance.myTime.week - 1].myDays.Count >= GameManager.instance.myTime.lastDayOfWeek
                && myQuarters.Count < GameManager.instance.myTime.lastQuarter)
        {
            currentQuarter = new quarterCheck();
            UI.instance.initCalendar();
        }
        else
        {
            //ending goes here.
        }
    }

    public void insertDayUnit(dayCheck dayUnit)
    {
        GameTime myTime = GameManager.instance.myTime;
        currentQuarter.myWeeks[myTime.week - 1].myDays.Add(dayUnit);

        if (currentQuarter.myWeeks.Count < myTime.lastWeek && currentQuarter.myWeeks[myTime.week - 1].myDays.Count >= myTime.lastDayOfWeek)
            insertWeekUnit();
    }

    public void insertTimeUnit(timeUnitCheck timeUnit)
    {
        if (currentDay.myTimeUnits == null)
            currentDay.myTimeUnits = new List<timeUnitCheck>();
        GameTime myTime = GameManager.instance.myTime;
        currentDay.myTimeUnits.Add(timeUnit);
    }
}
