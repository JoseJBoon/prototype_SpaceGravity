using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public float cursorMinDistance = 1.0f;
    public float cursorMaxDistance = 10.0f;

    [SerializeField]
    Transform cursor;

    public void SetCursorLocation(Vector3 mouseWorldPosition)
    {
        if(!cursor)
            return;

        Vector3 offset = mouseWorldPosition - transform.position;
        
        if(offset.magnitude < cursorMinDistance)
            offset = offset.normalized * cursorMinDistance;
        else if(offset.magnitude > cursorMaxDistance)
            offset = offset.normalized * cursorMaxDistance;

        cursor.position = transform.position + offset;
    }
}