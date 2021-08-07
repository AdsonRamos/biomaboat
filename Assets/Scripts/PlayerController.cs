using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Newtonsoft.Json.Linq;
// using NDream.AirConsole;

public class PlayerController : MonoBehaviour
{   
    public float boatSpeed = 2.0f;
    public float playerSpeed = 2.0f;
    public float speedMultiplicator = 0.2f;
    public bool airConsole = false;
    private Transform playerTransform;
    private new Rigidbody rigidbody;
    // private bool movedRight = false;
    // private bool movedLeft = false;
    // private bool connected = false;
    // public static bool gameStarted = false;


    void Start()
    {
        playerTransform = gameObject.transform;
        rigidbody = playerTransform.GetComponent<Rigidbody>();

        // if (!airConsole) {
        //     connected = true;
        // }
    }

    // void Awake () {
    //     if (airConsole) {
    //         AirConsole.instance.onMessage += OnMessage;			
    //         AirConsole.instance.onConnect += OnConnect;	
    //     }
    // }

    // void OnMessage (int from, JToken data) {
    //     Debug.Log ("message: " + data);
    //     this.ButtonInput (data["action"].ToString());
    // }

    // void OnConnect (int device){
    //     Debug.Log ("Successfully connected with device " + device);
    //     connected = true;
    // }

    // public void ButtonInput (string input) {
    //     Debug.Log (input);
    //     switch (input) {
    //         case "right":
    //             movedRight = true;
    //             break;
    //         case "left":
    //             movedLeft = true;
    //             break;
    //         case "right-up":
    //             movedRight = false;
    //             break;
    //         case "left-up":
    //             movedLeft = false;
    //             break;
    //         }
    // }

    void Update() {   
        if (AirConsoleController.connected) {
            if (AirConsoleController.gameStarted) {
                boatSpeed += speedMultiplicator * Time.deltaTime;
                rigidbody.AddForce(rigidbody.transform.forward * Time.deltaTime * boatSpeed);

                Vector3 PlayerMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                rigidbody.AddForce(PlayerMove * Time.deltaTime * playerSpeed, ForceMode.Acceleration);

                if (AirConsoleController.movedLeft && !AirConsoleController.movedRight) {
                    rigidbody.AddForce(Vector3.left * Time.deltaTime * playerSpeed, ForceMode.Acceleration);
                } else if (!AirConsoleController.movedLeft && AirConsoleController.movedRight) {
                    rigidbody.AddForce(Vector3.right * Time.deltaTime * playerSpeed, ForceMode.Acceleration);
                }
            }
        }
    }

    // void OnDestroy () {
    //     if (airConsole) {
    //         if (AirConsole.instance != null) {
    //             AirConsole.instance.onMessage -= OnMessage;				
    //             AirConsole.instance.onConnect -= OnConnect;		
    //         }
    //     }
    // }
}
