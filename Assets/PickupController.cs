using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private float bobAmount = 0.006f;
    private float bobSpeed = 2f;

    private GameObject pickedObject;
    private float distanceToPick = 4f;
    private float pickupSpeed = 10f;

    [SerializeField]
    private Transform pivot;
    
    private float throwForce = 10f;

    private Rigidbody pickedObjectRigidbody;

    // Update is called once per frame
    void Update()
    {
        if (pickedObject && Vector3.Distance(transform.position, pickedObject.transform.position) <= distanceToPick)
        {
            pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            pickedObject.transform.position = Vector3.Lerp(pickedObject.transform.position, pivot.transform.position,
                Time.deltaTime * pickupSpeed);

            pickedObject.transform.position = new Vector3(pickedObject.transform.position.x,
                                                        pickedObject.transform.position.y + Mathf.Sin(Time.time * bobSpeed) * bobAmount,
                                                          pickedObject.transform.position.z);

            pickedObject.transform.rotation = pivot.transform.rotation;
        }
    }

    public void PickObject(GameObject gameObject)
    {
        pickedObject = gameObject;
        pickedObjectRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void ThrowObject()
    {
        if (!pickedObject) return;

        pickedObjectRigidbody.isKinematic = false;

        pickedObjectRigidbody.AddForce((pivot.forward + pivot.up).normalized * throwForce, ForceMode.Impulse);

        pickedObject = null;
    }

    public void DropObject()
    {
        if (!pickedObject) return;

        pickedObjectRigidbody.isKinematic = false;
        pickedObject = null;
    }
}