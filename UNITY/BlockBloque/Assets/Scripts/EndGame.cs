using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    private string final_time;
    private string score_file_as_string;
    // Start is called before the first frame update
    void Start()
    {
        GameObject timer_controller = GameObject.Find("timer_controller");
        final_time = timer_controller.GetComponent<Timer>().time;
        GameObject time_box = GameObject.Find("Time_Box");
        time_box.GetComponent<Text>().text = final_time;

        //Update Feedback and News text boxes dependant on whether or not the user set a high score.
        //First we need to open the high scores text file.
        GameObject write_file = GameObject.Find("Write&Sound");
        score_file_as_string = write_file.GetComponent<WriteFile>().ReadFile();
        Debug.Log(score_file_as_string);
        //Now to parse these into user and score pairs.
        string[] strs = score_file_as_string.Split('|');
        List<string> list = new List<string>(strs);
     
        bool name = false;
        for (int i = 0; i < list.Capacity; i++)
        {
            name = !name;
            if(name)
            {
                
            }
            Debug.Log(list[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
