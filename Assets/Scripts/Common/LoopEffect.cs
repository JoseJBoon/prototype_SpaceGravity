using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Use interface/abstract classes
public class LoopEffect : MonoBehaviour
{
    [SerializeField]
    float delayBetweenToggle = 2.0f;

    FadeSprite fade;
    ScaleGameObject scaling;

    void Awake()
    {
        fade = GetComponent<FadeSprite>();
        scaling = GetComponent<ScaleGameObject>();
    }

    void Start()
    {
        StartCoroutine(ToggleBetween());
    }

    IEnumerator ToggleBetween()
    {
        while(true)
        {
            fade.StartFade();
            scaling.StartScaling();

            yield return new WaitForSeconds(delayBetweenToggle);

            fade.ReverseFade();
            scaling.ReverseScaling();

            yield return new WaitForSeconds(delayBetweenToggle);
        }
    }
}
