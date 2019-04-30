using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Text displayText;
    public Text displayText2;
    public Text displayText3;

    // Start is called before the first frame update
    void Start()
    {

        displayText.text = "Click the run button to start testing!";

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Run()
    {
        if (Test_IsPresent_Master())
        {
            displayText.text = "Beginning Testing... Master object PASSED";
        }
        else
        {
            displayText.text = "Master Object Failed!";
        }

        if (Test_IsPresent_BlockTango())
        {
            displayText2.text = "Block Tango PASSED";
        }
        else
        {
            displayText2.text = "Block Tango Failed";
        }

        if (Test_IsPresent_timer())
        {
            displayText3.text = "timer found. Test PASSED";
        }
        else
        {
            displayText3.text = "timer not found. Test Failed";
        }

    }

    public bool Test_IsPresent_Master()
    {
        //Returns true if GameObject named "Master" is found, else false.
        return GameObject.Find("Master");
    }

    public bool Test_IsPresent_BlockTango()
    {
        return GameObject.Find("Write&Sound").transform.Find("Audio Source");
    }
    public bool Test_IsPresent_timer()
    {
        return GameObject.Find("timer_controller");
    }

}

