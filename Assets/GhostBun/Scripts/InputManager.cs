using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 50f;

    [SerializeField]
    GameObject force;

    [SerializeField]
    GameObject anchor;

    [SerializeField]
    GameObject player;

    [SerializeField]
    NavMeshAgent navMeshAgent;

    [SerializeField]
    LayerMask mask;

    [SerializeField]
    float timerToGo = 0.1f;

    float touchTimer = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchTimer = 0;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anchor.SetActive(false);
            navMeshAgent.enabled = true;
            if (touchTimer < timerToGo)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100, mask))
                {
                    navMeshAgent.destination = hit.point;
                }
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (touchTimer < timerToGo)
            {
                touchTimer += Time.deltaTime;
            }
            else
            {
                if (!anchor.activeInHierarchy)
                {
                    navMeshAgent.enabled = false;
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 100, mask))
                    {
                        anchor.transform.position = hit.point;
                    }
                    if (!force.activeInHierarchy)
                    {
                        anchor.SetActive(true);
                    }
                    anchor.GetComponent<Anchor>().SetDistance(Vector3.Distance(anchor.transform.position, player.transform.position));
                    anchor.transform.LookAt(player.transform, Vector3.up);
                }
                anchor.GetComponent<Anchor>().ChangeVectorHorizontal(Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed);
                anchor.GetComponent<Anchor>().ChangeVectorVertical(Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed);
            }
        }
    }
}
