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

    /**
    * Method: Start()
    * Params: None.
    * Description: If the level has a place to display the user's name, this method does it.
    */
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

    /**
    * Method: Update()
    * Params: None.
    * Description: Once per frame this method checks if the user has won the level or pressed pause, then acts accordingly.
    */
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

    /**
    * Method: GoToLevel()
    * Params: new_level: A string that is the name of the level to go to.
    * Description: Changes levels.
    */
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
