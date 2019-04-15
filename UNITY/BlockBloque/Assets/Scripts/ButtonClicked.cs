using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public Text inputText;

    /**
    * Method: ClickHandler()
    * Params: None
    * Description: For having "Master" change levels via button click.
    */
    public void ClickHandler()
    {
        GameObject master = GameObject.Find("Master");
        master.GetComponent<Master>().changeLevels = true;
    }
    
}
