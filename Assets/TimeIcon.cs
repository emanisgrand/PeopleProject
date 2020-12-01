using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIcon : MonoBehaviour
{

    public Image myImage; //reference to the image component

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>(); //get the image component upon start.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIcon(timeUnitCheck.timeUnitStatus status){

        if(status == timeUnitCheck.timeUnitStatus.success){
            myImage.color = Color.green;
        }

        if(status == timeUnitCheck.timeUnitStatus.failure){
            myImage.color = Color.grey;
        }

        if(status == timeUnitCheck.timeUnitStatus.consumed){
            myImage.color = new Color(0, 0, 0, 0);
        }
    }
}
