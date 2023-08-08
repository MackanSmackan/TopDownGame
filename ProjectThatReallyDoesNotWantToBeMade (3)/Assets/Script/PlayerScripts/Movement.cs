using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] Transform Player;
    [SerializeField] SpriteRenderer Forward;
    [SerializeField] SpriteRenderer Backwards;
    [SerializeField] SpriteRenderer Right;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] Animator Leftanimator;
    [SerializeField] Animator Forwardanimator;
    [SerializeField] Animator Rightanimator;
    [SerializeField] Animator Backanimator;
    [SerializeField] TrailRenderer ForwardTR;
    [SerializeField] TrailRenderer BackwardsTR;
    [SerializeField] TrailRenderer RightTR;
    [SerializeField] TrailRenderer LeftTR;
    [SerializeField] float AttackJump;
    bool Walking;
    public bool attacking;

    int CurrentAttack;


    [SerializeField] Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos = new Vector3(MousePos.x, MousePos.y, 1);
        float xDir;
        float yDir;
        xDir = Mathf.Abs(MousePos.x - Player.position.x);
        yDir = Mathf.Abs(MousePos.y - Player.position.y);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            StartCoroutine(Attacking());
        }

        if (xDir > yDir)
        {
            if (MousePos.x - Player.position.x < 0)
            {
                Right.enabled = true;
                Left.enabled = false;
                Forward.enabled = false;
                Backwards.enabled = false;
            }
            else
            {
                Left.enabled = true;
                Right.enabled = false;
                Forward.enabled = false;
                Backwards.enabled = false;
            }
        }
        else
        {
            if (MousePos.y - Player.position.y > 0)
            {
                Right.enabled = false;
                Left.enabled = false;
                Forward.enabled = false;
                Backwards.enabled = true;
            }
            else
            {
                Right.enabled = false;
                Left.enabled = false;
                Forward.enabled = true;
                Backwards.enabled = false;
            }
        }
        if (movement.x == 0 && movement.y == 0)
        {
            Walking = false;
        }
        else
        {
            Walking = true;
        }

        Forwardanimator.SetBool("Walking", Walking);
        Backanimator.SetBool("Walking", Walking);
        Leftanimator.SetBool("Walking", Walking);
        Rightanimator.SetBool("Walking", Walking);

    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Attacking()
    {
        if (Forward.enabled == true)
        {
            ForwardTR.enabled = true;
        }
        if (Backwards.enabled == true)
        {
            BackwardsTR.enabled = true;
        }
        if (Right.enabled == true)
        {
            LeftTR.enabled = true;
        }
        if (Left.enabled == true)
        {
            RightTR.enabled = true;
        }
        attacking = true;
        Walking = false;
        Forwardanimator.SetTrigger("Attack");
        Backanimator.SetTrigger("Attack");
        Leftanimator.SetTrigger("Attack");
        Rightanimator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f);
        attacking = false;
        Walking = true; 
        yield return new WaitForSeconds(0.2f);
        ForwardTR.enabled = false;
        BackwardsTR.enabled = false;
        LeftTR.enabled = false;
        RightTR.enabled = false;
    }
}
