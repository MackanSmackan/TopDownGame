using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] RigHandler Rigs;

    [Header("Movement")]
    [SerializeField] float Speed;
    Rigidbody2D rb;
    Vector2 dir;
    float xInput;
    float yInput;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        dir = new Vector2(xInput, yInput).normalized;

        SetVisualDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(dir * Speed, ForceMode2D.Force);
    }

    void SetVisualDirection()
    {
        if(xInput != 0 || yInput != 0)
        {
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                if (xInput > 0)
                {
                    Rigs.SetEast();
                }
                else
                {
                    Rigs.SetWest();
                }
            }
            else
            {
                if (yInput > 0)
                {
                    Rigs.SetNorth();
                }
                else
                {
                    Rigs.SetSouth();
                }
            }
        }
    }
}
