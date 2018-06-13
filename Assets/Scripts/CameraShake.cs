using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Camera mainCamera;
    public float shakeAmount = 0;

    public float lastShakeAmount;
    public float shakeDuration;


    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        Shake();
    }

    public void Shake()
    {
        if (shakeDuration > 0)
        {
            Vector3 camPos = mainCamera.transform.position;

            float shakeAmountX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmountY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += shakeAmountX;
            camPos.y += shakeAmountY;

            mainCamera.transform.position = camPos;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            mainCamera.transform.localPosition = Vector3.zero;
            shakeAmount = 0;
        }
    }

    public void ShakeTheCamera(float amount, float length)
    {
        shakeAmount = amount;
        shakeDuration = length;
    }
   
}
