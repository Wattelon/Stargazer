using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + target.forward * offset.z + target.up * offset.y;
        //Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref _velocity, smoothSpeed);
        transform.position = smoothedPos;
        transform.LookAt(target);
    }
}
