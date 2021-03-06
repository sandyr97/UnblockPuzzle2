﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class WriteFile : MonoBehaviour
{

    public string user_name;
    public string Path;
    public AudioSource blockTango;
    public InputField user_name_entry;

    private bool block_tango_on = false;


    /**
    * Method: ObtainUserWriteString()
    * Params: None.
    * Description: Logs the user's username for writing to file later.
    */
    public void ObtainUserWriteString()
    {
        // Get user name from text field at game start.
        Debug.Log(user_name_entry.text);
        // Write it to file.
        // WriteString(user_name_entry.text);
        //Store it in the WriteFile game object so we have it for future reference.
        user_name = user_name_entry.text;
        //if you dont want a user name, you get assigned user.
        if(user_name == "")
        {
            user_name = "User";
        }
    }

    public void WriteUserHighScore(int place)
    {

    }

    /**
    * Method: WriteString()
    * Params: string_to_write: The string to write to file.
    * Description: Writes a string to file.
    */
    public void WriteString(string string_to_write)
    {
        StreamWriter writer = new StreamWriter(Path, true);
        writer.WriteLine(string_to_write);
        writer.Close();
       // AssetDatabase.ImportAsset(Path);
       
    }

    /**
    * Method: ReadFile()
    * Params: None.
    * Description: Returns file contents as string.
    */
    public string ReadFile()
    {
        StreamReader reader = new StreamReader(Path);
        return reader.ReadToEnd();

    }

    /**
    * Method: Start()
    * Params: None.
    * Description: Dont destroy and play blocktango.
    */
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); //Whatever has this script will not be destroyed when levels change.

      
            blockTango.Play(); //play block tango.
   

    }

    // Update is called once per frame
    void Update()
    {
    }
}
