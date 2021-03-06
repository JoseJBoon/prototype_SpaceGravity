﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 500;

    // For when standing on a platform
    [HideInInspector]
    public MovePlatformBehaviour externalMomentum;

    Rigidbody2D m_rigidbody;
    BoxCollider2D m_box;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_box = GetComponent<BoxCollider2D>();
    }

    public void Move(float horizontal)
    {
        Vector2 movement = new Vector2(horizontal, 0) * speed;
        Vector2 externalVelocity = Vector2.zero;

        if (externalMomentum)
        {
            externalVelocity = externalMomentum.velocity;
            // Y velocity is already being maintained :D
            externalVelocity.y = 0;
        }
        
        m_rigidbody.velocity = new Vector2(movement.x, m_rigidbody.velocity.y) + externalVelocity;
    }

    public void Jump()
    {
        if(IsGrounded())
            m_rigidbody.AddForce(Vector2.up * jumpForce);            
    }

    bool IsGrounded()
    {     
        // TODO: Magic numbers
        // TODO: Try circle cast instead
        // Down left & right positions are in world space  
        Vector2 feetLeft = m_box.bounds.center - new Vector3(m_box.bounds.extents.x * .2f, m_box.bounds.extents.y);
        Vector2 feetRight = m_box.bounds.center + new Vector3(m_box.bounds.extents.x * .2f, -m_box.bounds.extents.y);
        
        RaycastHit2D hitLeft = Physics2D.Raycast(feetLeft, -transform.up, .1f);
        RaycastHit2D hitRight = Physics2D.Raycast(feetRight, -transform.up, .1f);

        if(hitLeft && hitRight)
            return true;          

        return false;
    }
}
