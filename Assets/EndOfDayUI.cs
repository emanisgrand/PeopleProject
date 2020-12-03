using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfDayUI : MonoBehaviour
{

    public static EndOfDayUI instance;
    public List<Image> timeUnitImages;
    public GameObject timeUnitContainer;

    // Start is called before the first frame update
    void Start()
    {
        timeUnitContainer = gameObject.transform.GetChild(0).gameObject;

        timeUnitImages = new List<Image>();

        instance = this;

        for(int i = 0; i < timeUnitContainer.transform.childCount; i++)
        {
            timeUnitImages.Add(timeUnitContainer.transform.GetChild(i).gameObject.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEODView()
    {
        StartCoroutine("initEODView");
    }

    public IEnumerator initEODView()
    {
        yield return new WaitForSeconds(1.5f);

        dayCheck myDay = GameLog.instance.currentDay;

        for(int i = 0; i < myDay.myTimeUnits.Count; i++)
        {
            yield return new WaitForSeconds(.2f);

            if (myDay.myTimeUnits[i].myStatus == timeUnitCheck.timeUnitStatus.success)
            {
                timeUnitImages[i].color = Color.green;
            } else if (myDay.myTimeUnits[i].myStatus == timeUnitCheck.timeUnitStatus.failure)
            {
                timeUnitImages[i].color = Color.grey;
            }

        }

        GameLog.instance.insertDayUnit(myDay);
        UI.instance.updateCalendar();

    }
}
