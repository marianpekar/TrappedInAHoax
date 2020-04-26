using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float bobAmount = 0.001f;

    [SerializeField]
    private float bobSpeed = 4f;

    private Vector3 defaultPosition;
    private bool isMovingToTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingToTargetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, defaultPosition, Time.deltaTime * speed);
        }

        transform.position = new Vector3(transform.position.x, 
                                       transform.position.y + Mathf.Sin(Time.time * bobSpeed) * bobAmount,
                                         transform.position.z);
    }

    public void MoveToTargetPosition()
    {
        isMovingToTargetPosition = true;
    }

    public void MoveToDefaultPosition()
    {
        isMovingToTargetPosition = false;
    }
}
