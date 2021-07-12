using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string targetScene;


    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame() {
        targetScene = "Game";
        LoadingData.sceneToLoad = targetScene;
        SceneManager.LoadScene("Loading");
    }
}
