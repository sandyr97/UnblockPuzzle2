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
        bool name = false;
        //Note, list is much like a linked list and Add() adds to the back.
        List<List<string>> pairs = new List<List<string>>();
        List<string> operating_list = new List<string>();
        for(int i = 0; i < strs.Length;i++)
        {
            name = !name;
            if(name)
            {
                operating_list.Add(strs[i]);
            }
            else
            {
                operating_list.Add(strs[i]);
                pairs.Add(operating_list);
                operating_list = new List<string>();
            }
            
        }
        Debug.Log("Finished creating list.");
        //Now to find the first, second, and third highest scoring users.
        List<string> first = new List<string>();
        first.Add("Empty");
        first.Add("Empty");
        List<string> second = new List<string>();
        second.Add("Empty");
        second.Add("Empty");
        List<string> third = new List<string>();
        third.Add("Empty");
        third.Add("Empty");

        Debug.Log("Count: ");
        Debug.Log(pairs.Count);
        //Time to sort.
        List<double> scores = new List<double>();
        for(int i = 0; i < pairs.Count;i++)
        {
            scores.Add(System.Double.Parse(pairs[i][1]));
        }
        scores.Sort();
        //Select top 3 scores.
        for(int i = 0; i < pairs.Count; i++)
        {
            if(System.Double.Parse(pairs[i][1]) == scores[0])
            {
                //This pairing is first place!
                first[0] = pairs[i][0];
                first[1] = pairs[i][1];
            }
            else if(System.Double.Parse(pairs[i][1]) == scores[1])
            {
                //This pairing is second place!
                second[0] = pairs[i][0];
                second[1] = pairs[i][1];
            }
            else if(System.Double.Parse(pairs[i][1]) == scores[2])
            {
                //This pairing is third place!
                third[0] = pairs[i][0];
                third[1] = pairs[i][1];
            }
        }
        Debug.Log("First Place: ");
        Debug.Log(first[0]);
        Debug.Log(first[1]);
        Debug.Log("Second Place: ");
        Debug.Log(second[0]);
        Debug.Log(second[1]);
        Debug.Log("Third Place: ");
        Debug.Log(third[0]);
        Debug.Log(third[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
