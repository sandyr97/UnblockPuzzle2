using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Text displayText;
  
    // Start is called before the first frame update
    void Start()
    {

        displayText.text = "Click the run button to start testing!";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void run()
    {
        
        displayText.text = "Beginning Testing...";
        GameObject drag = GameObject.Find("Drag");
      


    }

}
