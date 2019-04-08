using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    public TextAsset users;

    // Start is called before the first frame update
    void Start()
    {
        StreamWriter writer = new StreamWriter("Assets/users.txt", true);
        writer.WriteLine("Evan,4000");
        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

