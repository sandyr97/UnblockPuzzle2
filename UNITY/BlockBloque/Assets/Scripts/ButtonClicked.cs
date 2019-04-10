using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public Text inputText;

    public void ClickHandler()
    {
        GameObject master = GameObject.Find("Master");
        //Debug.Log(inputText.text);
       // StreamWriter writer = new StreamWriter("Assets/users.txt", true);
        //writer.WriteLine(inputText.text);
       // writer.Close();
        master.GetComponent<Master>().changeLevels = true;
    }
    
}
