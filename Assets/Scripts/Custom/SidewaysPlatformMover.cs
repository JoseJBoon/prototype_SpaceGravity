using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class SidewaysPlatformMover : MonoBehaviour
    {
        public float speed = 1.0f;
        public float distance = 3.0f;
        public bool moveInXDirection = true;

        Rigidbody2D rb2d;
        Vector2 startPosition;
        float movement;

        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
        }

        void FixedUpdate()
        {
            movement = Mathf.Sin(Time.time * speed) * distance;
            Vector2 move = Vector2.zero;

            if (moveInXDirection)
                move.x = movement;
            else
                move.y = movement;

            rb2d.MovePosition(startPosition + move);

            movement = 0;
        }
    }

}

