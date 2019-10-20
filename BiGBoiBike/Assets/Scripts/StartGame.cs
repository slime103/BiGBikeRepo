using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reloading current level");
                ReloadCurrentLevel();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Loading next level");
                LoadNextLevel();
            }

            if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().buildIndex == 0)
            {
                LoadNextLevel();
            }
        }
    }

    void LoadScene(int sceneIndex)
    {
        Debug.Log("scene " + SceneManager.GetActiveScene().name + " time: " + Time.timeSinceLevelLoad);
        SceneManager.LoadScene(sceneIndex);
    }

    void ReloadCurrentLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            sceneIndex = 0;
        }
    }
}
