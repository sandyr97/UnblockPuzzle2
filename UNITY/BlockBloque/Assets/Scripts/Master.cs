using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{

    public string nextLevelName;
    public bool changeLevels = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (changeLevels)
        {
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
        }
    }
}
