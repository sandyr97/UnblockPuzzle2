using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public string time; /*<The time to display on the game UI>*/
    private float current = 0.0f; /*<The current time according to the Time class>*/

    /**
    * Method: Start()
    * Params: None.
    * Description: Create a timer, if there already is one, delete it.
    */
    void Start()
    {
        //No duplicate objects from reloading a scene.
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            GameObject toDelete = GameObject.Find("timer_controller");
            Destroy(toDelete);
        }
        //To ensure that the object holding the script is not destroyed between levels.
        DontDestroyOnLoad(this.gameObject);
    }

    /**
    * Method: Update()
    * Params: None.
    * Description: Once per frame iterate time and display it on any textbox named "time".
    */
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
