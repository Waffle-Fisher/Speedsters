using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Min(0)]
    public int sceneIndex;
    public void PlayGame()
    {
        Debug.Log("Lets play!");
        if(sceneIndex >= SceneManager.sceneCountInBuildSettings) { Debug.LogError("Trying to load a scene outside the current number of scenes in the build settings"); }
        SceneManager.LoadScene(sceneIndex);
    }

    //Make sure to know what scene index the levels areS
    public void setIndex(int index)
    {
        sceneIndex = index;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
