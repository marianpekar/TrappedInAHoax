using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedPlayer = null;

    private NavMeshAgent agent;
    private PickupController pickupController;

    void Start()
    {
        SelectPlayer(selectedPlayer);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            pickupController.ThrowObject();
        else if (Input.GetMouseButtonDown(2))
            pickupController.DropObject();

        if (!Input.GetMouseButtonDown(0)) return;

        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 1000)) return;

        var gameObject = hit.collider.gameObject;

        if (gameObject.CompareTag("Player"))
            SelectPlayer(gameObject);
        else
            SetTarget(hit.point);

        if (gameObject.CompareTag("Pickable"))
            pickupController.PickObject(gameObject);
    }

    void SetComponents(GameObject player)
    {
        agent = player.GetComponent<NavMeshAgent>();
        pickupController = player.GetComponent<PickupController>();
    }

    void SelectPlayer(GameObject player)
    {
        SetComponents(player);
        PlayerEvents<Transform>.Instance.OnPlayerSelected?.Invoke(player.transform);
        PlayerEvents<GameObject>.Instance.OnPlayerSelected?.Invoke(player);
    }

    void SetTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
