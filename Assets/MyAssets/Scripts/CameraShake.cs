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
        if (lastShakeAmount < shakeAmount)
        {
            lastShakeAmount = shakeAmount;
        }

        if (shakeDuration > 0)
        {
            Vector3 camPos = mainCamera.transform.position;

            float shakeAmountX = Random.value * lastShakeAmount * 2 - lastShakeAmount;
            float shakeAmountY = Random.value * lastShakeAmount * 2 - lastShakeAmount;

            camPos.x += shakeAmountX;
            camPos.y += shakeAmountY;

            mainCamera.transform.position = camPos;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            mainCamera.transform.localPosition = Vector3.zero;
            lastShakeAmount = 0;
        }
    }

    public void ShakeTheCamera(float amount, float length)
    {
        shakeAmount = amount;
        shakeDuration = length;
    }
    public void OverwriteCameraShake(float amount, float length)
    {
        shakeAmount = amount;
        shakeDuration = length;
    }

    //public void Shake(float amount, float length)
    //{
    //    if (GameController.instance.playerAlive == true)
    //    {
    //        shakeAmount = amount;
    //        InvokeRepeating("DoShake", 0, 0.01f);
    //        Invoke("StopShake", length);
    //    }

    //}
    //void DoShake()
    //{
    //    if (shakeAmount > 0)
    //    {
    //        Vector3 camPos = mainCamera.transform.position;

    //        float shakeAmountX = Random.value * shakeAmount * 2 - shakeAmount;
    //        float shakeAmountY = Random.value * shakeAmount * 2 - shakeAmount;

    //        camPos.x += shakeAmountX;
    //        camPos.y += shakeAmountY;

    //        mainCamera.transform.position = camPos;
    //    }
    //}
    //void StopShake()
    //{
    //    CancelInvoke("DoShake");
    //    mainCamera.transform.localPosition = Vector3.zero;
    //}
}
