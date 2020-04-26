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
    void OnTriggerEnter(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable") || otheCollider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Button pressed");
            OnButtonPressed.Invoke();
        }
    }

    void OnTriggerExit(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable") || otheCollider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Button released");
            OnButtonReleased.Invoke();
        }
    }
}
