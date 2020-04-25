using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;

    private GameObject selectedPlayer = null;
    private int currentPlayerIndex = 0;

    private NavMeshAgent agent;
    private PickupController pickupController;

    void Start()
    {
        SelectPlayer(players[currentPlayerIndex]);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Length)
                currentPlayerIndex = 0;

            SelectPlayer(players[currentPlayerIndex]);
        }

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
        selectedPlayer = player;
        SetComponents(player);
        PlayerEvents<Transform>.Instance.OnPlayerSelected?.Invoke(player.transform);
        PlayerEvents<GameObject>.Instance.OnPlayerSelected?.Invoke(player);
    }

    void SetTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
