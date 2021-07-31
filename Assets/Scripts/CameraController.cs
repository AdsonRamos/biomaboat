using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody player;
    public Vector3 offset = new Vector3(0, 0, 0);
    public float smoothSpeed = 0.1f;

    void Update()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, player.position.z + offset.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = SmoothedPosition;
    }
}
