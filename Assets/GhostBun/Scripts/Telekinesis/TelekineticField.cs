using System.Collections.Generic;
using UnityEngine;

public class TelekineticField : MonoBehaviour
{
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _maximumRadius = 2f;
    [SerializeField] private float _expansionSpeed = 10f;
    [SerializeField] private int _maximumObjectsInControl = 5;
    [SerializeField] private float _force;
    [SerializeField] private float _chaoticForce;
    [SerializeField] [Range(0, 1)] private float _startingRadius = 1f;
    [SerializeField] [Range(0, 1)] private float _expansionChaos = 0f;
    [SerializeField] [Range(0, 1)] private float _chaoticForse = 0f;

    private static List<Rigidbody> _rbList;
    private float _currentRadius = 0f;

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

        if (_rbList.Contains(body))        
            _rbList.Remove(body);        
    }

    private void OnDisable()
    {
        _rbList.Clear();
        _currentRadius = _startingRadius;
        transform.localScale = Vector3.one * _currentRadius;
    }

    private void FixedUpdate()
    {
        // Здесь коллайдер растет.
        if (_currentRadius < _maximumRadius)
        {
            _currentRadius += Time.fixedDeltaTime * (_expansionSpeed + (Random.Range(-0.5f * _chaoticForse, 1f * _chaoticForse) * _expansionChaos)); // Магических чисел лучше избегать.
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
            Vector3 directionalForce = (transform.position - _rbList[i].transform.position).normalized * _force;
            Vector3 randomForce = Random.insideUnitSphere * Random.Range(0, _chaoticForce) * Random.Range(0f, 2f);
            _rbList[i].AddForce((directionalForce + randomForce) * Time.fixedDeltaTime, _forceMode);
        }
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
