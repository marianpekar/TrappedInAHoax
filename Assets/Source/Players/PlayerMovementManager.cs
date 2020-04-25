using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementManager : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedPlayer;
    
    private NavMeshAgent agent; 

    void Start()
    {
        SetComponents(selectedPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 1000)) return;

        if (hit.collider.gameObject.CompareTag("Player"))
            SelectPlayer(hit.collider.gameObject);
        else
            SetTarget(hit.point);
    }

    void SetComponents(GameObject player)
    {
        agent = player.GetComponent<NavMeshAgent>();
    }

    void SelectPlayer(GameObject player)
    {
        SetComponents(player);
    }

    void SetTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
