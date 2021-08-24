using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using Newtonsoft.Json.Linq;
// using NDream.AirConsole;

public class PlayerController : MonoBehaviour
{   
    public float boatSpeed = 2.0f;
    public float playerSpeed = 2.0f;
    public float speedMultiplicator = 0.2f;
    private Transform playerTransform;
    private new Rigidbody rigidbody;


    void Start()
    {
        playerTransform = gameObject.transform;
        rigidbody = playerTransform.GetComponent<Rigidbody>();

    }

    void Update() {   
        if (AirConsoleController.connected) {
            if (AirConsoleController.gameStarted) {
                if (AirConsoleController.gameRestarted) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    AirConsoleController.gameRestarted = false;
                }
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
}
