using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    private Dictionary<Rigidbody, BodyData> savedBodies;


    public void Startup()
    {
        Debug.Log("Items manager starting...");

        foreach (Rigidbody rb in FindObjectsOfType<Rigidbody>()) 
        {
        	savedBodies.Add(rb, new BodyData()
        	{
        	    position = rb.transform.position,
        	    rotation = rb.transform.rotation,
        	    velocity = rb.velocity,
        	    angularVelocity = rb.angularVelocity
        	});
        }
        // foreach(BodyData body in savedBodies)
        // {
        // 	body.Value.position = body.Key.transform.position;
        // 	body.Value.rotation = body.Key.transform.rotation;
        // 	body.Value.velocity = body.Key.velocity;
        // 	body.Value.angularVelocity = body.Key.angularVelocity;
        // }

        Status = ManagerStatus.Started;
    }


    public void AddBody(Rigidbody rb)
    {
    	savedBodies.Add(rb, new BodyData()
    	{
        	position = rb.transform.position,
        	rotation = rb.transform.rotation,
        	velocity = rb.velocity,
        	angularVelocity = rb.angularVelocity
        });
    }
}

public class BodyData // struct? Maybe useable for save/load data manager.
{
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 velocity;
	public Vector3 angularVelocity;
    // mass.
    // layer?
}