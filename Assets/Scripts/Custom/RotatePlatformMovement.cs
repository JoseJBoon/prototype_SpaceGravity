using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class RotatePlatformMovement : MonoBehaviour
    {
        public float speed = 1.0f;
        public float distance = 3.0f;

        Rigidbody2D rb2d;
        Vector2 startPostion;

        float x;
        float y;

        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            startPostion = transform.position;
        }

        void FixedUpdate()
        {
            x = Mathf.Sin(Time.time * speed) * distance;
            y = Mathf.Cos(Time.time * speed) * distance;

            rb2d.MovePosition(startPostion + new Vector2(x, y));

            x = y = 0;
        }
    }

}
