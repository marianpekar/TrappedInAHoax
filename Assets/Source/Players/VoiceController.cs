using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField] 
    private AudioClip[] catchphrases;

    private int currentCatchphraseIndex = 0;

    // Update is called once per frame
    public void PlayNextCatchPhrase()
    {
        currentCatchphraseIndex++;

        if (currentCatchphraseIndex >= catchphrases.Length)
            currentCatchphraseIndex = 0;

        audioSource.clip = catchphrases[currentCatchphraseIndex];
        audioSource.Play();
    }
}
