using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public string current_level_name;
    public GameObject pause_menu;
    public GameObject game_ui;
    public AudioSource block_tango;
    public Slider volume_handler;

    /**
    * Method: Start()
    * Params: None.
    * Description: Attempts to acquire the Audio Source object.
    */
    void Start()
    {
        if(GameObject.Find("Audio Source"))
        {
            GameObject write = GameObject.Find("Audio Source");
            block_tango = write.GetComponent<AudioSource>();
        }
    }
    /**
    * Method: Update()
    * Params: None.
    * Description: Once per frame, the audio volume is set to match the volume slider.
    */
    void Update()
    {
        block_tango.volume = volume_handler.value;
    }

    /**
    * Method: GoToLevel()
    * Params: new_level: a string that is the name of the new level.
    * Description: Changes levels.
    */
    public void GoToLevel(string new_level)
   {
        if (new_level == "LandingPage")
        {
            block_tango.Stop();
            //also destroy the Write&Sound object.
            GameObject ws = GameObject.Find("Write&Sound");
            Destroy(ws);
        }
        SceneManager.LoadScene(new_level, LoadSceneMode.Single);
    }
      /**
      * Method: ResetLevel()
      * Params: None.
      * Description: Restarts the current level.
      */
    public void ResetLevel()
   {
      
        GoToLevel(current_level_name);
   }
    /**
    * Method: QuitGame()
    * Params: None.
    * Description: Closes the application.
    */
    public void QuitGame()
   {
       Application.Quit();
   }
    /**
    * Method:Resume()
    * Params: None.
    * Description: Closes the pause menu.
    */
    public void Resume()
    {
        GameObject master = GameObject.Find("Master");
        master.GetComponent<Master>().is_paused = false;
        pause_menu.SetActive(false);
        game_ui.SetActive(true);
    }
}
