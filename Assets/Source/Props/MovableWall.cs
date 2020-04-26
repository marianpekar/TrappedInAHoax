using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition;

    [SerializeField]
    private float speed;

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
