using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;

    // Update is called once per frame
    void OnCollisionEnter(Collision otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable"))
        {
            OnButtonPressed.Invoke();
        }
    }

    void OnCollisionExit(Collision otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable"))
        {
            OnButtonReleased.Invoke();
        }
    }
}
