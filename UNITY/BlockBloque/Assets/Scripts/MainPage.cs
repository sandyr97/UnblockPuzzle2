using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainPage : MonoBehaviour
{
    public TextAsset users;
    public Text inputTxt;
    // Start is called before the first frame update
    void Start()
    {
        StreamWriter writer = new StreamWriter("Assets/users.txt", true);
        writer.WriteLine();
        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
