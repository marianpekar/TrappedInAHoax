using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FootstepsController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if(agent.remainingDistance <= 0.1)
            Stop();
    }

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
