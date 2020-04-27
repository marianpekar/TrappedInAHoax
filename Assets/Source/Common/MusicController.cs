using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    void Awake()
    {
        var instance = FindObjectOfType<MusicController>();

        if (instance != this)
            Destroy(instance.gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
