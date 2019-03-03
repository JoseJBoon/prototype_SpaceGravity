using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolBehaviour : MonoBehaviour
{
    public abstract void OnPrimaryBehaviour();
    public abstract void OnSecondaryBehaviour();
    public abstract void OnPrimaryReleaseBehaviour();
    public abstract void OnSecondaryReleaseBehaviour();
}