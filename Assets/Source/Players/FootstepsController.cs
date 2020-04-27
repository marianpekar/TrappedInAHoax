using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FootstepsController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private NavMeshAgent agent;

    private float footstepsVolume = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (agent.remainingDistance <= 0.1)
            audioSource.volume = 0;
        else
            audioSource.volume = footstepsVolume;
    }
}
