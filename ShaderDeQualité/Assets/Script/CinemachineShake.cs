using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    [SerializeField] private float intensityAmplitude;
    [SerializeField] private float intensityFrequency;
    [SerializeField] private float time;

    public GameObject Bomb;
    
    public static CinemachineShake instance;
    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        }

        //gameObject.transform.rotation = new Quaternion(25, -135, 0,0);
    }

    public void ShakeCamera(float intensityAmplitude, float intensityFrequency, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensityAmplitude;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = intensityFrequency;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0f;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bomb, new Vector3(Random.Range(-3,3),0, Random.Range(-3,3)), quaternion.identity);
            ShakeCamera(intensityAmplitude,intensityFrequency,time);
        }
        
    }
}