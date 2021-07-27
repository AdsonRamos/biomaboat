using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public class PlayerController : MonoBehaviour
{   
    private Vector3 playerVelocity;
    private Transform playerTransform;
    private new Rigidbody rigidbody;
    float accelerationForce = 5f;
    public float boatSpeed = 2.0f;
    public float playerSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
        rigidbody = playerTransform.GetComponent<Rigidbody>();
    }

    void Awake () {
		AirConsole.instance.onMessage += OnMessage;
	}

    void OnMessage (int from, JToken data){
		Debug.Log ("message: " + data);

		this.ButtonInput (data["action"].ToString());
	}

    public void ButtonInput (string input){
		switch (input) {
            case "right":
                Debug.Log ("Right pressed!");
                rigidbody.AddForce(Vector3.right * accelerationForce, ForceMode.Impulse);
                break;
            case "left":
                Debug.Log ("Left pressed!");
                rigidbody.AddForce(Vector3.left * accelerationForce, ForceMode.Impulse);
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

    // Update is called once per frame
    void Update()
    {   
        rigidbody.AddForce(Vector3.forward * Time.deltaTime * boatSpeed);

        Vector3 PlayerMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rigidbody.AddForce(PlayerMove * Time.deltaTime * playerSpeed, ForceMode.Force);
    }
}
