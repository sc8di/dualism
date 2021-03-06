﻿using System.Collections.Generic;
using UnityEngine;

public class GhostBun : MonoBehaviour
{
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _force;
    [SerializeField] private float _bunSpeed = 5f;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _stopThreshold = 0.2f;

    private List<Rigidbody> _rbList;
    private Vector3 _startingLocation;
    private Quaternion _startingRotation;
    private Rigidbody _body;
    private float _distanceToTarget;

    private Vector3 _xyz;

    private void Start()
    {
        _rbList = new List<Rigidbody>();
        _startingLocation = transform.position;
        _startingRotation = transform.rotation;
        _body = GetComponent<Rigidbody>();
        _xyz = Vector3.one;
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            if (_target.activeInHierarchy)
            {
                _distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
                if (_distanceToTarget > _stopThreshold)
                {
                    transform.LookAt(_target.transform);
                    _body.MovePosition(transform.position + transform.forward * _bunSpeed * Time.fixedDeltaTime);
                    _xyz += Vector3.one;
                    _body.MoveRotation(Quaternion.Euler(_xyz));
                }
            }
            else
            {
                _distanceToTarget = Vector3.Distance(transform.position, _startingLocation);
                if (_distanceToTarget > _stopThreshold)
                {
                    transform.LookAt(_startingLocation);
                    _body.MovePosition(transform.position + transform.forward * _bunSpeed * Time.fixedDeltaTime);
                    _xyz += Vector3.one;
                    _body.MoveRotation(Quaternion.Euler(_xyz));
                }
            }

            ///Бегаем по записям.
            for (int i = 0; i < _rbList.Count; i++)
            {
                //Если объект уже уничтожен, не существует, убираем его из листа.
                if (!_rbList[i])
                {
                    _rbList.RemoveAt(i);
                    i--;
                    continue;
                }
                Vector3 directionalForce = (transform.position - _rbList[i].transform.position).normalized * _force;
                _rbList[i].AddForce(directionalForce * Time.fixedDeltaTime, _forceMode);
            }
        }
        else
        {
            _xyz += Vector3.one;
            _body.MoveRotation(Quaternion.Euler(_xyz));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;

        if (body && !_rbList.Contains(body))        
            _rbList.Add(body);        
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;

        if (body)        
            _rbList.Remove(body);
    }

}
