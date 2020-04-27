using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;

    [SerializeField]
    private Material pressedMaterial;

    [SerializeField]
    private Material releasedMaterial;

    private Renderer renderer;

    [SerializeField] 
    private AudioSource buttonPressed;

    [SerializeField]
    private AudioSource buttonReleased;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Pickable") || otherCollider.gameObject.CompareTag("Player"))
        {
            buttonPressed.Play();
        }
    } 

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Pickable") || otherCollider.gameObject.CompareTag("Player"))
        {
            OnButtonPressed.Invoke();
            SetMaterial(pressedMaterial);
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Pickable") || otherCollider.gameObject.CompareTag("Player"))
        {
            SetMaterial(releasedMaterial);
            buttonReleased.Play();
            OnButtonReleased.Invoke();
        }
    }

    void SetMaterial(Material material)
    {
        var materials = renderer.materials;
        materials[1] = material;
        renderer.materials = materials;
    }
}
