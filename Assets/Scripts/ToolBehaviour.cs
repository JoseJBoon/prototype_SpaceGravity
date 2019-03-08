using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolBehaviour : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Color toolColor = new Color(1.0f, 1.0f, 0, 1.0f);

    void OnEnable()
    {
        if (spriteRenderer)
            spriteRenderer.color = toolColor;
    }

    public abstract void OnPrimaryBehaviour();
    public abstract void OnSecondaryBehaviour();
    public abstract void OnPrimaryReleaseBehaviour();
    public abstract void OnSecondaryReleaseBehaviour();
}