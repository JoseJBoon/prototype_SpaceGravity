using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Can we create a more Generic/Abstract version of the class?
public class ScaleGameObject : MonoBehaviour
{
    [SerializeField]
    Vector3 endScale;
    [SerializeField]
    float speed = 1.0f;

    Vector3 startScale; // Scale of transform
    Vector3 targetScale;
    bool isScaling;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        if (!isScaling)
            return;

        Vector3 currentScale = transform.localScale;
        currentScale = Vector3.Lerp(currentScale, targetScale, speed * Time.deltaTime);

        if (Vector3.Distance(currentScale, targetScale) < 0.01f)
        {
            currentScale = targetScale;
            isScaling = false;
        }
            

        transform.localScale = currentScale;
    }

    public void StartScaling()
    {
        targetScale = endScale;
        isScaling = true;
    }

    public void ReverseScaling()
    {
        targetScale = startScale;
        isScaling = true;
    }

}
