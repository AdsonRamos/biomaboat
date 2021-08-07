using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using Newtonsoft.Json.Linq;
// using NDream.AirConsole;

public class MainMenu : MonoBehaviour
{
    // public GameObject hud;
    
    // void Awake () {
	// 	AirConsole.instance.onMessage += OnMessage;		
	// 	AirConsole.instance.onReady += OnReady;		
	// 	AirConsole.instance.onConnect += OnConnect;		
    //     hud.SetActive(false);
	// }

    // void OnReady(string code){
	// 	Debug.Log ("Welcome to my AirConsole example!");
	// }

	// void OnConnect (int device){
	// 	Debug.Log ("Successfully connected with device " + device);
	// }

    // void OnMessage (int from, JToken data){
	// 	Debug.Log ("message: " + data);

	// 	this.ButtonInput (data["action"].ToString());
	// }

    // public void ButtonInput (string input){
	// 	switch (input) {
    //         case "start":
    //             Debug.Log (MenuSelect.currentItem);
    //             if (MenuSelect.currentItem == 0) {
    //                 this.StartGame ();
    //             } else if (MenuSelect.currentItem == 1) {
    //                 Application.Quit();
    //             }
    //             break;
    //         case "left":
    //             MenuSelect.currentItem = 0;
    //             break;
    //         case "right":
    //             MenuSelect.currentItem = 1;
    //             break;
    //         }
	// }

    // public void StartGame() {
    //     Debug.Log ("Started!");
    //     hud.SetActive(true);
    //     gameObject.SetActive(false);
    //     PlayerController.gameStarted = true;
    // }

    // void OnDestroy () {
	// 	if (AirConsole.instance != null) {
	// 		AirConsole.instance.onMessage -= OnMessage;		
	// 		AirConsole.instance.onReady -= OnReady;		
	// 		AirConsole.instance.onConnect -= OnConnect;		
	// 	}
	// }
}
