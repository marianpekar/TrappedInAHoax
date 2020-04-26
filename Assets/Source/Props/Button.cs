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

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable") || otheCollider.gameObject.CompareTag("Player"))
        {
            SetMaterial(pressedMaterial);
            OnButtonPressed.Invoke();
        }
    }

    void OnTriggerExit(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable") || otheCollider.gameObject.CompareTag("Player"))
        {
            SetMaterial(releasedMaterial);
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
