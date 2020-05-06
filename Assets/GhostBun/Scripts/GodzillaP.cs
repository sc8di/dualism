using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GodzillaP : MonoBehaviour
{
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private AudioSource _stomp;
    private AllRigidbodies _allrb;
    [SerializeField] private float shakeCameraLength = 0.3f;

    CinemachineBasicMultiChannelPerlin noise;

    public float force = 500f;

    private void Start()
    {
        noise = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _allrb = FindObjectOfType<AllRigidbodies>();
        gameObject.SetActive(false);
    }

    private void PushByStep()
    {
        StartCoroutine(ShakeCamera(shakeCameraLength));
        _allrb.AddForceToAll(transform.up + Random.onUnitSphere * force, _forceMode);
        _stomp.Play();
    }

    private IEnumerator ShakeCamera(float seconds)
    {
        noise.m_AmplitudeGain = 3;
        yield return new WaitForSeconds(seconds);
        noise.m_AmplitudeGain = 0;
    }


    private void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
