﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour
{
    CharacterController2D controller;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    void FixedUpdate()
    {
        controller.Move(Input.GetAxis("Horizontal"));

        if(Input.GetButtonDown("Jump"))
            controller.Jump();   
    }
}
