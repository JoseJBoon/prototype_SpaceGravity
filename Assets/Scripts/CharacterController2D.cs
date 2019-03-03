using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 500;

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
        m_rigidbody.velocity = new Vector2(movement.x, m_rigidbody.velocity.y);
    }

    public void Jump()
    {
        if(IsGrounded())
            m_rigidbody.AddForce(Vector2.up * jumpForce);            
    }

    bool IsGrounded()
    {     
        // Down left & right positions are in world space  
        Vector2 feetLeft = m_box.bounds.center - m_box.bounds.extents;
        Vector2 feetRight = m_box.bounds.center + new Vector3(m_box.bounds.extents.x, -m_box.bounds.extents.y);
        
        RaycastHit2D hitLeft = Physics2D.Raycast(feetLeft, -transform.up, .1f);
        RaycastHit2D hitRight = Physics2D.Raycast(feetRight, -transform.up, .1f);

        if(hitLeft && hitRight)
            return true;          

        return false;
    }
}
