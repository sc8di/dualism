﻿using System.Collections.Generic;
using UnityEngine;

public class TelekineticField : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float angularDestabilization;
    [SerializeField] private float _nullForceRadius;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _maximumRadius = 2f;
    [SerializeField] private float _expansionSpeed = 10f;
    [SerializeField] private int _maximumObjectsInControl = 5;
    [SerializeField] private float _force;
    [SerializeField] private float _startingRadius = 1f;
    [SerializeField] private float _chaoticForce;

    private static List<Rigidbody> _rbList;
    private float _currentRadius = 0f;
    private Vector3 _lastFramePosition = Vector3.zero;
    private Vector3 _deltaForce = Vector3.zero;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _nullForceRadius * _currentRadius);
    }

    private void Start()
    {
        _rbList = new List<Rigidbody>();
        transform.localScale = Vector3.one * _currentRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;

        if (body && !_rbList.Contains(body) && _rbList.Count < _maximumObjectsInControl)        
            _rbList.Add(body);
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;
        body.useGravity = true;
        if (_rbList.Contains(body))        
            _rbList.Remove(body);        
    }

    private void OnDisable()
    {
        foreach (Rigidbody body in _rbList)
            body.useGravity = true;

        _rbList.Clear();
        _currentRadius = _startingRadius;
        transform.localScale = Vector3.one * _currentRadius;
    }

    private void OnEnable()
    {
        _lastFramePosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Здесь коллайдер растет.
        if (_currentRadius < _maximumRadius)
        {
            _currentRadius += Time.fixedDeltaTime * _expansionSpeed; // Магических чисел лучше избегать.
            transform.localScale = Vector3.one * _currentRadius;
        }

        // Сортировка по массе.
        if (_rbList.Count > 1) 
            _rbList.Sort(new SortByMass());

        // Непосредственное притяжение.
        for (int i = 0; (i < (_rbList.Count < _maximumObjectsInControl ? _rbList.Count : _maximumObjectsInControl)); i++)
        {
            if (!_rbList[i])
            {
                _rbList.RemoveAt(i);
                i--;
                continue;
            }

            _rbList[i].useGravity = false;

            _rbList[i].angularVelocity = _rbList[i].angularVelocity * angularDestabilization;

            float objectDistance = Vector3.Distance(_rbList[i].transform.position, transform.position);

            Vector3 chaoticForceVector = Random.insideUnitSphere * Random.Range(0, _chaoticForce) * Random.Range(0f, 2f);

            if (objectDistance > _nullForceRadius * _currentRadius)
            {
                Vector3 directionalForce = (transform.position - _rbList[i].transform.position).normalized * _force;
                _rbList[i].AddForce(directionalForce * Time.fixedDeltaTime, _forceMode);
            }
            else
            {
                //Считаем изменение положения локации телекинеза.
                _deltaForce = transform.position - _lastFramePosition;
                //Добавляем силу для перемещения 
                _rbList[i].AddForce(_deltaForce, ForceMode.VelocityChange);
            }
            _rbList[i].AddForce(chaoticForceVector * Time.fixedDeltaTime, _forceMode);

        }
        //Записываем текущую позицию как предыдущую.
        _lastFramePosition = transform.position;
    }

    private sealed class SortByMass : IComparer<Rigidbody>
    {
        int IComparer<Rigidbody>.Compare(Rigidbody _objA, Rigidbody _objB)
        {
            float t1 = _objA.mass;
            float t2 = _objB.mass;
            return t1.CompareTo(t2);
        }
    }
}
