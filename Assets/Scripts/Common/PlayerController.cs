using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform toolTarget;

    CharacterController2D controller;
    SpawnAtCheckpointBehaviour checkpoint;
    CursorBehaviour cursor;
    ToolBehaviour[] tools;
    int currentTool = 0;

    Vector3 mouseWorldPosition;
    float xMovement;
    bool jump;
    bool spawnAtCheckpoint;
    Camera mainCamera;
    GameManager gameManager;

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
        checkpoint = GetComponent<SpawnAtCheckpointBehaviour>();
        gameManager = GameManager.Instance;

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

        if (Input.GetButtonDown("Fire1"))
        {
            if (gameManager.GetPlayerUnlocks().PrimaryFire)
                CurrentTool.OnPrimaryBehaviour();
            else
                Debug.Log("I need an energy cell to use the primary fire.");
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (gameManager.GetPlayerUnlocks().SecondaryFire)
                CurrentTool.OnSecondaryBehaviour();
            else
                Debug.Log("I need a negative engery cell to use the secondary fire.");
        }
        else if (Input.GetButtonUp("Fire1"))
            CurrentTool.OnPrimaryReleaseBehaviour();
        else if (Input.GetButtonUp("Fire2"))
            CurrentTool.OnSecondaryReleaseBehaviour();

        if (Input.GetKeyDown(KeyCode.R))
            spawnAtCheckpoint = true;
            
    }

    void FixedUpdate()
    {
        controller.Move(xMovement);
        xMovement = 0;

        if(jump)
        {
            jump = false;
            controller.Jump();
        }

        if(spawnAtCheckpoint)
        {
            spawnAtCheckpoint = false;
            checkpoint.SpawnAtCheckpoint();
        }
    }

    void LateUpdate()
    {
        // TODO: Place in update
        cursor.SetCursorLocation(mouseWorldPosition);
        
        Vector3 direction = cursor.GetCursorLocalPosition();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 90.0f;

        toolTarget.localPosition = direction.normalized * 1.0f;
        toolTarget.localRotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        
    }

    void SwapTool()
    {
        if (gameManager.GetPlayerUnlocks().WeaponSwappingUnlocked)
            return;

        CurrentTool?.gameObject.SetActive(false);
        currentTool = (currentTool + 1) % tools.Length;
        CurrentTool?.gameObject.SetActive(true);
    }
}
