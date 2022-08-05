using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cineCamera;
    private float shakeTimer = 1.5f;
    private float startingIntensity = 1f;
    private float shakeFrequency;

    private void Awake()
    {
        cineCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float frequency, float time)
    {
        CinemachineBasicMultiChannelPerlin shaker = cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        shaker.m_AmplitudeGain = intensity;
        shaker.m_FrequencyGain = frequency;
        startingIntensity = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin shaker = cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                shaker.m_AmplitudeGain = 0f;
            }   
        }
    }
}
