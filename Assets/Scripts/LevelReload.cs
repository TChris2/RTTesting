using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReload : MonoBehaviour
{
    void Update()
    {
        //checks if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Tab)) {
            //reloads the scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
