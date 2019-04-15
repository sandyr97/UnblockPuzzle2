using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public string current_level_name;

   public void GoToLevel(string new_level)
   {
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
}
