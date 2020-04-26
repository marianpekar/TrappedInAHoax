using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    private int players;
    private int playersToFinish = 2;
    private float delayBeforeLoadNextScene = 2f;

    public UnityEvent OnFinish;

    // Update is called once per frame
    void OnTriggerEnter(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Player"))
        {
            players++;
            Debug.Log($"{players} on finish line");

            if (players >= playersToFinish)
            {
                OnFinish.Invoke();
                Invoke("LoadNextScene", delayBeforeLoadNextScene);
            }
        }
    }

    void LoadNextScene()
    {
        FindObjectOfType<SceneLoader>().LoadNext();
    }

    void OnTriggerExit(Collider otheCollider)
    {
        if (otheCollider.gameObject.CompareTag("Player"))
        {
            players--;

            if (players < 0)
                players = 0;

            Debug.Log($"{players} on finish line");
        }
    }
}
