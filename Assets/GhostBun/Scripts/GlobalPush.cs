using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GlobalPush : MonoBehaviour
{
    [SerializeField] private AudioSource _shake;
    public float force = 500f;
    [SerializeField]
    ForceMode forceMode;
    [SerializeField] private float shakeCameraLength = 0.3f;

    CinemachineBasicMultiChannelPerlin noise;

    AllRigidbodies allrb;
    bool atstart = true;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 arrowEnd = transform.forward * 6 + transform.position;
        Gizmos.DrawLine(transform.position, arrowEnd);
        Gizmos.DrawLine(arrowEnd, -transform.right + arrowEnd + -transform.forward);
        Gizmos.DrawLine(arrowEnd, transform.right + arrowEnd + -transform.forward);
    }

    private void Start()
    {
        noise = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        allrb = FindObjectOfType<AllRigidbodies>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (!atstart)
        {
            StartCoroutine(ShakeCamera(shakeCameraLength));
        }
    }

    private void OnDisable()
    {
        atstart = false;
    }

    private IEnumerator ShakeCamera(float seconds)
    {
        _shake.Play();
        allrb.AddForceToAll(transform.forward * force, forceMode);
        noise.m_AmplitudeGain = 3;
        yield return new WaitForSeconds(seconds);
        noise.m_AmplitudeGain = 0;
        gameObject.SetActive(false);
    }
}
