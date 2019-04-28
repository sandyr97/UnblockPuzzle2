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

    void Start()
    {
        if(GameObject.Find("Audio Source"))
        {
            GameObject write = GameObject.Find("Audio Source");
            block_tango = write.GetComponent<AudioSource>();
        }
    }
    void Update()
    {
        block_tango.volume = volume_handler.value;
    }

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
   public void ResetLevel()
   {
      
        GoToLevel(current_level_name);
   }
   public void QuitGame()
   {
       Application.Quit();
   }
    public void Resume()
    {
        GameObject master = GameObject.Find("Master");
        master.GetComponent<Master>().is_paused = false;
        pause_menu.SetActive(false);
        game_ui.SetActive(true);
    }
}
