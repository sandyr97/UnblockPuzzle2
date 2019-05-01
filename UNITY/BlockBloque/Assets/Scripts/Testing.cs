using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Text resultText1;
    public Text resultText2;
    public Text resultText3;
    public Text resultText4;
    public Text resultText5;
    public Text resultText6;

    public GameObject timer_controller;

    // Start is called before the first frame update
    void Start()
    {
        resultText1.text = "Click the run button to start testing!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    * Method: run()
    * Params: None.
    * Description: runs all testing.
    */
    public void run()
    {
        string str1 = "Test 1. Master GameObject acquirable: ";
        string str2 = "Test 2. Write&Sound GameObject acquirable: ";
        string str3 = "Test 3. Audio Source GameObject acquirable: ";
        string str4 = "Test 4. Users file is accessible: ";
        string str6 = "";

        if(Test_isPresent_Master())
        {
            str1 += "PASS";
        }
        else
        {
            str1 += "FAIL";
        }

        if (Test_isPresent_WriteFile())
        {
            str2 += "PASS";
        }
        else
        {
            str2 += "FAIL";
        }

        if (Test_isPresent_AudioSource())
        {
            str3 += "PASS";
        }
        else
        {
            str3 += "FAIL";
        }



        if (Test_UsersFile_isAccessible())
        {
            str4 += "PASS";
        }
        else
        {
            str4 += "FAIL";
        }

        resultText1.text = str1;
        resultText2.text = str2;
        resultText3.text = str3;
        resultText4.text = str4;
    }

    /**
    * Method: Test_isPresent_Master()
    * Params: None.
    * Description: Verifies that the Master GameObject is accessible.
    */
    public bool Test_isPresent_Master()
    {
        return GameObject.Find("Master");
    }
    /**
   * Method: Test_isPresent_WriteFile()
   * Params: None.
   * Description: Verifies that the Write&Sound GameObject is accessible.
   */
    public bool Test_isPresent_WriteFile()
    {
        return GameObject.Find("Write&Sound");
    }
    /**
   * Method: Test_isPresent_AudioSource()
   * Params: None.
   * Description: Verifies that the Audio Source GameObject is accessible.
   */
    public bool Test_isPresent_AudioSource()
    {
        return GameObject.Find("Audio Source");
        
    }
    /**
   * Method: Test_UsersFile_isAccessible()
   * Params: None.
   * Description: Verifies that the Useres.txt file is accessible.
   */
    public bool Test_UsersFile_isAccessible()
    {
        string test = GameObject.Find("Write&Sound").GetComponent<WriteFile>().ReadFile();
        if (test == "") return false;
        return true;
    }
}
