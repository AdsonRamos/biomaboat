using UnityEngine;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public class AirConsoleController : MonoBehaviour
{   
    public static bool connected = false;
    public static bool gameStarted = false;
    public static bool movedRight = false;
    public static bool movedLeft = false;
    public GameObject hud;
    public GameObject mainMenu;

    void Awake () {
        AirConsole.instance.onMessage += OnMessage;			
        AirConsole.instance.onConnect += OnConnect;	
        hud.SetActive(false);
    }

    void OnMessage (int from, JToken data) {
        Debug.Log ("message: " + data);
        this.ButtonInput (data["action"].ToString());
    }

    void OnConnect (int device){
        Debug.Log ("Successfully connected with device " + device);
        connected = true;
    }

    public void ButtonInput (string input) {
        switch (input) {
            case "start":
                if (gameStarted) {
                    mainMenu.SetActive(true);
                    gameStarted = false;
                    hud.SetActive(false);
                } else {
                    if (MenuSelect.currentItem == 0) {
                        this.StartGame ();
                    } else if (MenuSelect.currentItem == 1) {
                        Application.Quit();
                    }
                }
                break;
            case "right":
                if (gameStarted) {
                    movedRight = true;
                } else {
                    MenuSelect.currentItem = 1;
                }
                break;
            case "left":
                if (gameStarted) {
                    movedLeft = true;
                } else {
                    MenuSelect.currentItem = 0;
                }
                break;
            case "right-up":
                if (gameStarted) {
                    movedRight = false;
                }
                break;
            case "left-up":
                if (gameStarted) {
                    movedLeft = false;
                }
                break;
            }
    }

    public void StartGame() {
        hud.SetActive(true);
        mainMenu.SetActive(false);
        gameStarted = true;
    }

    void OnDestroy () {
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;
			AirConsole.instance.onConnect -= OnConnect;		
		}
	}
}