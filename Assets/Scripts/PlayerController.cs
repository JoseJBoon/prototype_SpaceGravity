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
    ToolBehaviour[] tools;
    int currentTool = 0;

    Vector3 mouseWorldPosition;
    float xMovement;
    bool jump;
    Camera mainCamera;

    public ToolBehaviour CurrentTool
    {
        get
        {
            if(tools.Length == 0)
                return null;

            return tools[currentTool];
        }
    }

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        cursor = GetComponent<CursorBehaviour>();
        tools = GetComponentsInChildren<ToolBehaviour>(true);

        mainCamera = Camera.main;
    }

    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));

        if(Input.GetButtonDown("Jump"))
            jump = true;

        if(Input.GetKeyDown(KeyCode.Tab))
            SwapTool();

        if(Input.GetButtonDown("Fire1"))
            CurrentTool.OnPrimaryBehaviour();
        else if(Input.GetButtonDown("Fire2"))
            CurrentTool.OnSecondaryBehaviour();
        else if(Input.GetButtonUp("Fire1"))
            CurrentTool.OnPrimaryReleaseBehaviour();
        else if(Input.GetButtonUp("Fire2"))
            CurrentTool.OnSecondaryReleaseBehaviour();
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

    void SwapTool()
    {
        Debug.Log("Woot");
        CurrentTool?.gameObject.SetActive(false);
        currentTool = (currentTool + 1) % tools.Length;
        CurrentTool?.gameObject.SetActive(true);
    }
}
