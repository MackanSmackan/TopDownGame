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

    [Header("Keybinds")]
    [SerializeField] KeyCode AttackKey = KeyCode.Mouse0;

    [Header("Attack")]
    public bool Attack1Over;
    public bool Attacking;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!Attacking)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            dir = new Vector2(xInput, yInput).normalized;
            SetVisualDirection();
        }

        if (Input.GetKeyDown(AttackKey) && !Attacking)
        {
            dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized;
            rb.velocity = Vector2.zero;
            xInput = dir.x;
            yInput = dir.y;
            SetVisualDirection();
            rb.AddForce(dir * 10, ForceMode2D.Impulse);
            StartCoroutine(Attack());
        }
    }

    private void FixedUpdate()
    {
        if (!Attacking)
        {
            Move();
        }
    }

    private void Move()
    {
        rb.AddForce(dir * Speed, ForceMode2D.Force);
    }

    void SetVisualDirection()
    {
        if(xInput != 0 | yInput != 0)
        {
            Rigs.SetRigAnimatorBool("Walking", true);
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
        else
        {
            Rigs.SetRigAnimatorBool("Walking", false);
        }
    }

    IEnumerator Attack()
    {
        Rigs.SetRigAnimatorInt("Attack", 1);
        Rigs.SetRigAnimatorBool("Walking", false);
        Attacking = true;
        Attack1Over = false;
        yield return new WaitForSeconds(0.3f);
        Attack1Over = true;
        Attacking = false;
        Rigs.SetRigAnimatorInt("Attack", 0);
    }
}
