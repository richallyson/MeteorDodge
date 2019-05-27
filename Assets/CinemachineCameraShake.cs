using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CinemachineCameraShake : MonoBehaviour {

    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter
    private float ShakeElapsedTime = 0f;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    bool _isShaking;
    void Start()
    {
        if (VirtualCamera != null){
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    void Update()
    {
        if (_isShaking)
        {   
            ShakeElapsedTime = ShakeDuration;
        }

        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            if (ShakeElapsedTime > 0)
            {
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }

    public void ShakeTheCamera(bool shake){
        if (shake == true){
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake(){
        _isShaking = true;
        yield return new WaitForSecondsRealtime(1.0f);
        _isShaking = false;
    }

}