using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class WriteFile : MonoBehaviour
{
    public string Path = "Assets/TextFiles/users.txt";
    public AudioSource blockTango;
    
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
