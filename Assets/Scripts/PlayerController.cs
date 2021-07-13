using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Vector3 playerVelocity;
    private Transform playerTransform;
    private new Rigidbody rigidbody;
    public float boatSpeed = 2.0f;
    public float playerSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
        rigidbody = playerTransform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        rigidbody.AddForce(Vector3.forward * Time.deltaTime * boatSpeed);

        Vector3 PlayerMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rigidbody.AddForce(PlayerMove * Time.deltaTime * playerSpeed, ForceMode.Force);
    }
}
