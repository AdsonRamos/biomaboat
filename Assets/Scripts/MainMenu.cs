using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public class MainMenu : MonoBehaviour
{
    void Awake () {
		AirConsole.instance.onMessage += OnMessage;		
		AirConsole.instance.onReady += OnReady;		
		AirConsole.instance.onConnect += OnConnect;		
	}

    void OnReady(string code){
		Debug.Log ("Welcome to my AirConsole example!");
	}

	void OnConnect (int device){
		Debug.Log ("Successfully connected with device " + device);
	}

    void OnMessage (int from, JToken data){
		Debug.Log ("message: " + data);

		this.ButtonInput (data["action"].ToString());
	}

    public void ButtonInput (string input){
		switch (input) {
            case "right":
                Debug.Log ("Right pressed!");
                break;
            case "left":
                Debug.Log ("Left pressed!");
                break;
            case "right-up":
                Debug.Log ("Right-up pressed!");
                break;
            case "left-up":
                Debug.Log ("Left-up pressed!");
                break;
            case "up":
                Debug.Log ("Up pressed!");
                break;
            case "down":
                Debug.Log ("Down pressed!");
                break;
            }
	}

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    void OnDestroy () {
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;		
			AirConsole.instance.onReady -= OnReady;		
			AirConsole.instance.onConnect -= OnConnect;		
		}
	}
}
