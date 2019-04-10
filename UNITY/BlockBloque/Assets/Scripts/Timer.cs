using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public string time;
    private float current = 0.0f;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
 
        time = current.ToString();
        GameObject timertext = GameObject.Find("time");
        timertext.GetComponent<Text>().text = "Time:" + time;
    }

    
}
