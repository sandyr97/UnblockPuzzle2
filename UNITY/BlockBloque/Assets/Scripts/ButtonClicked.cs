using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{


    public void ClickHandler()
    {
        GameObject master = GameObject.Find("Master");
        master.GetComponent<Master>().changeLevels = true;
    }
    
}
