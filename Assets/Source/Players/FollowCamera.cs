using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject target;
    private Vector3 currentLookPosition = Vector3.zero;
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 offset = new Vector3(0f, -10f, -15f);

    [SerializeField]
    private GameObject[] players;

    void Start()
    {
        PlayerEvents<GameObject>.Instance.OnPlayerSelected += (target) =>
        {
            this.target = target;
        };
    }

    void Update()
    {
        currentPosition = Vector3.Lerp(currentPosition, target.transform.position - offset, Time.deltaTime);
        transform.position = currentPosition;

        currentLookPosition = Vector3.Lerp(currentLookPosition, target.transform.position, Time.deltaTime);
        transform.LookAt(currentLookPosition);
    }
}
