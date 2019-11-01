using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.05f;//higher = faster lockon
    public float smoothSpeedSlam = 1f;
    public Vector3 offSet;


    private void FixedUpdate()//done after target done movement
    {
        if (target == null)
        {
            return;
        }
        Vector3 wantedPos = target.position + offSet;
        if (PlayerMovement.instance.isCrouched)
        {
            Vector3 smoothedPos = Vector3.Lerp(transform.position, wantedPos, smoothSpeedSlam);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(smoothedPos.y, -4.5f, 2.5f), transform.position.z);
        }
        else
        {
            Vector3 smoothedPos = Vector3.Lerp(transform.position, wantedPos, smoothSpeed);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(smoothedPos.y, -4.5f, 2.5f), transform.position.z);
        }
    }

}
