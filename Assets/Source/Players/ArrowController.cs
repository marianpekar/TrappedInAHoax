using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private float rotationSpeed = 120f;
    private float bobAmount = 0.1f;
    private float bobSpeed = 4f;
    private Vector3 offset = new Vector3(0f, 4f, 0);

    private Transform playerTransform;

    void Start()
    {
        PlayerEvents<Transform>.Instance.OnPlayerSelected += (transform) => playerTransform = transform;
    }

    void LateUpdate()
    {
        transform.Rotate((transform.position - playerTransform.position).normalized, rotationSpeed * Time.deltaTime, Space.World);
        transform.position = new Vector3(offset.x + playerTransform.position.x,
                                         offset.y + playerTransform.position.y + Mathf.Sin(Time.time * bobSpeed) * bobAmount, 
                                         offset.z + playerTransform.position.z);
    }
}
