using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floatCounter = 1;
    public float waterDrag = 0.1f;
    public float waterAngularDrag = 0.5f;

    void FixedUpdate() {
        rigidBody.AddForceAtPosition(Physics.gravity / floatCounter, transform.position, ForceMode.Acceleration);
        
        float waveWeight = Waves.instance.GetWaveYPos(
            transform.position.x,
            transform.position.z
        );

        if (transform.position.y < waveWeight) {
            // calculate displacement multiplier
            float displacementMultiplier = Mathf.Clamp01(
                (waveWeight - transform.position.y) / depthBeforeSubmerged
            ) * displacementAmount;
            // apply displacement
            rigidBody.AddForceAtPosition(
                new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),
                transform.position, ForceMode.Acceleration
            );
            rigidBody.AddForce(displacementAmount * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementAmount * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
