using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
    bool isShaking = false;
    float shakeTimer = 0.0f;

    private void Awake() {
        originalPos = camTransform.position;
        shakeTimer = shakeDuration;
    }

	void Update()
	{
        if (isShaking == true && shakeTimer > 0) {
            camTransform.localPosition += Random.insideUnitSphere * shakeAmount;
			shakeTimer -= Time.deltaTime * decreaseFactor;
        } else {
			shakeTimer = shakeDuration;
            isShaking = false;
		}
	}

    public void Shake()
    {
        isShaking = true;
        originalPos = camTransform.localPosition;
    }
}