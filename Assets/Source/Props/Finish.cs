using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public UnityEvent OnFinish;

    private int players;
    private int playersToFinish;

    // Update is called once per frame
    void OnTriggerEnter(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Player"))
        {
            players++;
            Debug.Log($"{players} on finish line");

            if (players >= playersToFinish)
                OnFinish.Invoke();
        }
    }

    void OnTriggerExit(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Pickable") || otheCollider.gameObject.CompareTag("Player"))
        {
            players--;

            if (players < 0)
                players = 0;

            Debug.Log($"{players} on finish line");
        }
    }
}
