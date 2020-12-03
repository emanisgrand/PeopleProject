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
        myQuarters.Add(new quarterCheck());
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

        if (currentQuarter.myWeeks.Count > myTime.lastWeek)
        {
            insertQuarterUnit();
            currentQuarter = new quarterCheck();
        }
    }

    public void insertDayUnit(dayCheck dayUnit)
    {
        GameTime myTime = GameManager.instance.myTime;
        myQuarters[myTime.quarter - 1].myWeeks[myTime.week - 1].myDays.Add(dayUnit);

        if (myQuarters[myTime.quarter - 1].myWeeks[myTime.week - 1].myDays.Count >= myTime.lastDayOfWeek)
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
