using System.Collections.Generic;
using UnityEngine;

public class PowerTrip : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public float mass;
    public float attachedMass;
    public int itemsUnderControl;
    public float gravity = -9.8f;
    public float physicsTimeStep;

    private Rigidbody _fieldRb;
    private HashSet<Rigidbody> _affectedBodies;
    private Vector3 _location;
    private Vector3 _currentVelocity;

    private void Awake()
    {
        //Time.fixedDeltaTime = physicsTimeStep;
        _affectedBodies = new HashSet<Rigidbody>();
    }

    private void Start()
    {
        _fieldRb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
        _fieldRb.mass = mass;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;

        if (body != null &&
            body.mass <= attachedMass &&
            itemsUnderControl > _affectedBodies.Count)
        {
            body.useGravity = false;

            _affectedBodies.Add(body);

            if (!Managers.Items.BodyContains(body))
                Managers.Items.AddBody(body);


            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            //rb.drag = 100f;
            //rb.angularDrag = rb.drag;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;

        if (body != null)
        {
            body.useGravity = true;
            _affectedBodies.Remove(body);

            //rb.drag = 0f;
            //rb.angularDrag = .05f;
            // rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void Attract(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.position;

        body.AddForce(gravityUp * gravity);
        body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = _location + new Vector3(0, 1.5f, 0);

            foreach (Rigidbody body in _affectedBodies)
            {
                //UpdateVelocity(body, physicsTimeStep);
                // ------------------------
                //Attract(rb);
                // ------------------------
                Vector3 directionToPoint = (transform.position - body.position).normalized;
                float distance = (transform.position - body.position).magnitude;
                float strength = body.mass * mass / distance;

                //rb.MovePosition(Vector3.Lerp(body.position, transform.position, strength * Time.fixedDeltaTime * 5f));
                body.MovePosition(body.position + (transform.position - body.position));
                //body.MovePosition(body.position + directionToPoint);

                body.AddForce(directionToPoint * strength * Time.fixedDeltaTime);
                body.AddRelativeTorque(directionToPoint * strength * Time.fixedDeltaTime);
            }
            // ------------------------
            //foreach (Rigidbody body in affectedBodies)
            //{
            //UpdatePosition(body, physicsTimeStep);
            //}
        }
    }

    // Shit.
    public void UpdateVelocity(Rigidbody body, float timeStep)
    {
        float sqrDistance = (transform.position - body.position).sqrMagnitude;
        Vector3 forceDirection = (transform.position - body.position).normalized;
        Vector3 force = forceDirection * physicsTimeStep * body.mass * _fieldRb.mass / sqrDistance;
        Vector3 acceleration = force / _fieldRb.mass;
        _currentVelocity += acceleration * timeStep;
    }

    // Shit.
    public void UpdatePosition(Rigidbody rb, float timeStep)
    {
        rb.position += _currentVelocity * timeStep;
    }

    public void DisableField()
    {
        if (_affectedBodies != null)
        {
            foreach (Rigidbody body in _affectedBodies)
            {
                body.useGravity = true;

                //rb.constraints = RigidbodyConstraints.None;
                //rb.drag = 0f;
                //rb.angularDrag = .05f;
            }
            _affectedBodies.Clear();
        }

        gameObject.SetActive(false);
    }

    public void EnableField()
    {
        gameObject.SetActive(true);
    }

    public void SetLocation(Vector3 newLocation)
    {
        _location = newLocation;
    }
}