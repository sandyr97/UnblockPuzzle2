using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Master : MonoBehaviour
{

    public string nextLevelName;
    public bool changeLevels = false;

    public GameObject canvas;
    public GameObject pause_canvas;

    private GameObject WriteFileObject;
    public bool is_paused = false;

    // Use this for initialization
    void Start()
    {
        if(nextLevelName != "LevelOne")
        {
            //Then we will need to display the player's username somewhere on screen.
            WriteFileObject = GameObject.Find("Write&Sound");
            GameObject usernameDisplay = GameObject.Find("UsernameText");
            usernameDisplay.GetComponent<Text>().text = WriteFileObject.GetComponent<WriteFile>().user_name;
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (changeLevels)
        {
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_paused = !is_paused;
            if(is_paused)
            {
                canvas.SetActive(false);
                pause_canvas.SetActive(true);
            }
            else
            {
                canvas.SetActive(true);
                pause_canvas.SetActive(false);
            }
            
            Debug.Log("They want to pause!");
        }
    }

    
        public void GoToLevel(string new_level)
        {
            if (new_level == "LandingPage")
            {
                //block_tango.Stop();
                //also destroy the Write&Sound object.
                GameObject ws = GameObject.Find("Write&Sound");
                Destroy(ws);
            }
            SceneManager.LoadScene(new_level, LoadSceneMode.Single);
        }
    
}
