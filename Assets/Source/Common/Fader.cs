using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] 
    private Image overlay;

    [SerializeField]
    private bool isFading;
    private float currentAlpha;
    private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentAlpha = overlay.color.a;
    }

    public void FadeIn()
    {
        isFading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading && currentAlpha <= 1.0f)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, 1.0f, Time.deltaTime * speed);
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, currentAlpha);
        }
        else if (!isFading && currentAlpha > 0f)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, 0, Time.deltaTime);
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, currentAlpha);
        }
    }
}