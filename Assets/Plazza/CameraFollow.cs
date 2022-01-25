using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] [Range(0.1f, 1f)] float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // 

    // [SerializeField] float zoom;
    private Vector3 velocity = Vector3.zero;
    // private bool flag = false;
    // private Camera cam;
    // private void Awake()
    // {
    //     cam = GetComponent<Camera>();
    // }
    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed);

        // if (target.position.x > trigger.x && flag == false)
        // {
        //     cam.orthographicSize *= zoom;
        //     flag = true;
        //     minCameraPos.x += 9;
        //     minCameraPos.y += 9;
        //     maxCameraPos.x -= 9;
        //     maxCameraPos.y -= 3;
        // }
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }


    }
}


