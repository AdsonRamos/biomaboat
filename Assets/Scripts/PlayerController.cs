using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public class PlayerController : MonoBehaviour
{   
    public float boatSpeed = 2.0f;
    public float playerSpeed = 2.0f;
    public float accelerationForce = 5f;
    private Vector3 playerVelocity;
    private Transform playerTransform;
    private new Rigidbody rigidbody;
    private bool movedRight = false;
    private bool movedLeft = false;
    private bool connected = false;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
        rigidbody = playerTransform.GetComponent<Rigidbody>();
    }

    void Awake () {
        AirConsole.instance.onMessage += OnMessage;			
        AirConsole.instance.onConnect += OnConnect;	
    }

    void OnMessage (int from, JToken data){
      Debug.Log ("message: " + data);

      this.ButtonInput (data["action"].ToString());
    }

    void OnConnect (int device){
		Debug.Log ("Successfully connected with device " + device);
        connected = true;
	}

    public void ButtonInput (string input) {
      switch (input) {
        case "right":
            movedRight = true;
            break;
        case "left":
            movedLeft = true;
            break;
        case "right-up":
            movedRight = false;
            break;
        case "left-up":
            movedLeft = false;
            break;
        case "up":
            Debug.Log ("Up pressed!");
            break;
        case "down":
            Debug.Log ("Down pressed!");
            break;
        }
    }

    // Update is called once per frame
    void Update() {   
        if (connected) {
            rigidbody.AddForce(rigidbody.transform.forward * Time.deltaTime * boatSpeed);

            Vector3 PlayerMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            rigidbody.AddForce(PlayerMove * Time.deltaTime * playerSpeed, ForceMode.Acceleration);

            if (movedLeft && !movedRight) {
                rigidbody.AddForce(Vector3.left * Time.deltaTime * playerSpeed, ForceMode.Acceleration);
            } else if (!movedLeft && movedRight) {
                rigidbody.AddForce(Vector3.right * Time.deltaTime * playerSpeed, ForceMode.Acceleration);
            }
        }
    }

    void OnDestroy () {
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;				
			AirConsole.instance.onConnect -= OnConnect;		
		}
	}
}
