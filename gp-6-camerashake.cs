using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 originalPosition;
    private float shakeDuration = 2.5f;
    private float shakeIntensity = 0.5f; // Adjust this value as needed

    void Start() // Corrected method declaration
    {
        cameraTransform = transform; // Assign the camera's transform to the variable
        originalPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        Debug.Log("Shake duration: " + shakeDuration);

        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = originalPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Check for spacebar input
        {
            ShakeCamera(3.5f); // Adjust duration as needed
        }
    }

    public void ShakeCamera(float duration)
    {
        Debug.Log("Shake initiated with duration: " + duration);
        originalPosition = cameraTransform.localPosition;
        shakeDuration = duration;
    }
}