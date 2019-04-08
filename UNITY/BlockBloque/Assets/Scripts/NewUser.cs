using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartBehaviour : MonoBehaviour 
{
public TextAsset users;
public Texture buttonText;
public InputField name, score;


// Should run when play button is clicked
void OnPlay()
{
    //Write some text to the test.txt file
    StreamWriter writer = new StreamWriter("Assets/users.txt", true);
    writer.WriteLine();
    writer.Close();

}

}