using UnityEngine;
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

    public void ObtainUserWriteString()
    {
        // Get user name from text field at game start.
        Debug.Log(user_name_entry.text);
        // Write it to file.
        // WriteString(user_name_entry.text);
        //Store it in the WriteFile game object so we have it for future reference.
        user_name = user_name_entry.text;
    }


    public void WriteString(string string_to_write)
    {
        StreamWriter writer = new StreamWriter(Path, true);
        writer.WriteLine(string_to_write);
        writer.Close();
       // AssetDatabase.ImportAsset(Path);
       
    }
    public string ReadFile()
    {
        StreamReader reader = new StreamReader(Path);
        return reader.ReadToEnd();

    }

    // Use this for initialization
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
