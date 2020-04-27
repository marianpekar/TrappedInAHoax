using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;

    [SerializeField]
    private GameObject selectedPlayer;
    private int currentPlayerIndex = 0;

    private NavMeshAgent agent;
    private PickupController pickupController;
    private VoiceController voiceController;

    void Start()
    {
        SetComponents(selectedPlayer);
        PlayerEvents<Transform>.Instance.OnPlayerSelected?.Invoke(selectedPlayer.transform);
        PlayerEvents<GameObject>.Instance.OnPlayerSelected?.Invoke(selectedPlayer);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Length)
                currentPlayerIndex = 0;

            SelectPlayer(players[currentPlayerIndex]);
        }

        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.T))
        {
            pickupController.ThrowObject();
            SetTarget(selectedPlayer.transform.position);
        }
        else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.D))
        {
            pickupController.DropObject();
            SetTarget(selectedPlayer.transform.position);
        }

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
        voiceController = player.GetComponent<VoiceController>();
    }

    void SelectPlayer(GameObject player)
    {
        selectedPlayer = player;
        SetComponents(player);

        voiceController.PlayNextCatchPhrase();

        PlayerEvents<Transform>.Instance.OnPlayerSelected?.Invoke(player.transform);
        PlayerEvents<GameObject>.Instance.OnPlayerSelected?.Invoke(player);
    }

    void SetTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
