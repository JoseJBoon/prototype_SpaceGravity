using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform toolTarget;

    CharacterController2D controller;
    CursorBehaviour cursor;
    ToolBehaviour tool;

    Vector3 mouseWorldPosition;
    float xMovement;
    bool jump;
    Camera mainCamera;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        cursor = GetComponent<CursorBehaviour>();
        tool = GetComponentInChildren<GraveOToolBehaviour>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));

        if(Input.GetButtonDown("Jump"))
            jump = true;

        if(Input.GetButtonDown("Fire1"))
            tool.OnPrimaryBehaviour();
        else if(Input.GetButtonDown("Fire2"))
            tool.OnSecondaryBehaviour();
    }

    void FixedUpdate()
    {
        controller.Move(xMovement);

        if(jump)
        {
            jump = false;
            controller.Jump();
        }  
    }

    void LateUpdate()
    {
        cursor.SetCursorLocation(mouseWorldPosition);
        
        Vector3 direction = cursor.GetCursorLocalPosition();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 90.0f;

        toolTarget.localPosition = direction.normalized * 1.0f;
        toolTarget.localRotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        
    }
}
