using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprite : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float endAlpha;
    [SerializeField]
    float speed = 1.0f;

    SpriteRenderer spriteRenderer;
    float startAlpha; // Alpha color of sprite
    float targetAlpha;
    bool isFading;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startAlpha = spriteRenderer.color.a;
    }

    void Update()
    {
        if (!isFading)
            return;

        Color currentColor = spriteRenderer.color;
        currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, speed * Time.deltaTime);
        if (Mathf.Abs(currentColor.a - targetAlpha) < 0.01f)
        {
            currentColor.a = targetAlpha;
            isFading = false;
        }

        spriteRenderer.color = currentColor;
    }

    public void StartFade()
    {
        isFading = true;
        targetAlpha = endAlpha;
    }

    public void ReverseFade()
    {
        isFading = true;
        targetAlpha = startAlpha;
    }

}
