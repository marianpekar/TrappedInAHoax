using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private GameObject pickedUpGameObject;

    [SerializeField]
    private float distanceToPick = 3f;

    [SerializeField]
    private float pickupSpeed = 3f;

    [SerializeField]
    private Transform pivot;

    // Update is called once per frame
    void Update()
    {
        if (pickedUpGameObject && Vector3.Distance(transform.position, pickedUpGameObject.transform.position) <= distanceToPick)
        {
            pickedUpGameObject.GetComponent<Rigidbody>().isKinematic = true;
            pickedUpGameObject.transform.position = Vector3.Lerp(pickedUpGameObject.transform.position, pivot.transform.position, Time.deltaTime * pickupSpeed);
            pickedUpGameObject.transform.rotation = pivot.transform.rotation;
        }
    }

    public void PickObject(GameObject gameObject)
    {
        pickedUpGameObject = gameObject;
    }

    public void ReleaseObject()
    {
        if (!pickedUpGameObject) return;

        pickedUpGameObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedUpGameObject = null;
    }
}
