using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    [SerializeField]
    float maximumVertical = 10f;

    float targetAngle = 0;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject playerMark;

    [SerializeField]
    GameObject anchorMark;

    public void SetDistance(float distance)
    {
        playerMark.transform.localPosition = transform.forward * distance;
        anchorMark.transform.localPosition = -transform.forward * distance;
    }

    public void ChangeVectorHorizontal(float angle)
    {
        transform.eulerAngles += new Vector3(0, angle, 0);
        player.transform.position = playerMark.transform.position;
    }

    public void ChangeVectorVertical(float angle)
    {
        if (((targetAngle + angle) < maximumVertical) && ((targetAngle + angle) > -maximumVertical))
        {
            targetAngle += angle;
            transform.eulerAngles = new Vector3(targetAngle, transform.eulerAngles.y, 0);
        }
    }

    private void OnDisable()
    {
        targetAngle = 0;
        transform.eulerAngles = Vector3.zero;
    }
}
