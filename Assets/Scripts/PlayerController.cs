using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour
{
    CharacterController2D controller;

    float xMovement;
    bool jump;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
            jump = true;
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
}
