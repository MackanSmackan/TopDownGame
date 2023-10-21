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
    [SerializeField] float AttackForce;

    public bool Attacking;
    public bool DoAttack2;
    bool CanAttack2;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if (!Attacking) // If not attacking then you should move
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            dir = new Vector2(xInput, yInput).normalized;
            SetVisualDirection();
        }

        if (Input.GetKeyDown(AttackKey) && !Attacking | CanAttack2) // Attack input
        {
            if (!Attacking)
            {
                StartCoroutine(Attack());
            }
            else if (CanAttack2)
            {
                CanAttack2 = false;
                DoAttack2 = true;
            }
        }        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!Attacking)
        {
            rb.AddForce(dir * Speed, ForceMode2D.Force);
        }
    }

    void SetVisualDirection()
    {
        if(xInput != 0 | yInput != 0)
        {
            if (!Attacking)
            {
                Rigs.SetRigAnimatorBool("Walking", true);
            }
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
        // Apply Directional force
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        rb.velocity = Vector2.zero;
        xInput = dir.x;
        yInput = dir.y;
        SetVisualDirection();
        rb.AddForce(-dir.normalized * AttackForce, ForceMode2D.Impulse);

        Rigs.SetRigAnimatorBool("Walking", false);
        Rigs.SetRigAnimatorInt("Attack", 1);

        Attacking = true;
        CanAttack2 = true;
        yield return new WaitForSeconds(0.4f);
        CanAttack2 = false;

        //Check how to continue
        if (!DoAttack2)
        {
            //End Attack
            Attacking = false;
            Rigs.SetRigAnimatorInt("Attack", 0);
            DoAttack2 = false;
        }
        else
        {
            Rigs.SetRigAnimatorInt("Attack", 2);

            // Apply Directional force
            dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized;
            rb.velocity = Vector2.zero;
            xInput = dir.x;
            yInput = dir.y;
            SetVisualDirection();
            rb.AddForce(-dir * AttackForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);

            //End attack
            Attacking = false;
            Rigs.SetRigAnimatorInt("Attack", 0);
            DoAttack2 = false;
        }
    }
}
