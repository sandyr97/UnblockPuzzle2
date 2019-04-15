using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public string time; /*<The time to display on the game UI>*/
    private float current = 0.0f; /*<The current time according to the Time class>*/

    // Use this for initialization
    void Start()
    {
        //To ensure that the object holding the script is not destroyed between levels.
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    //Iterate time, display it in any text box available named "time".
    void Update()
    {

        if (GameObject.Find("time"))
        {
            current += Time.deltaTime;
 
            time = current.ToString().Substring(0,7);
        
            GameObject timertext = GameObject.Find("time");
            timertext.GetComponent<Text>().text = "Time:" + time;
        }
       
    }

    
}
