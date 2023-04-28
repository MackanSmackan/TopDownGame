using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] SpriteRenderer Forward;
    [SerializeField] SpriteRenderer Backwards;
    [SerializeField] SpriteRenderer Right;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] Animator Leftanimator;
    [SerializeField] Animator Forwardanimator;
    [SerializeField] Animator Rightanimator;
    [SerializeField] Animator Backanimator;
    bool Walking;
    public bool attacking;


    [SerializeField] Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attacking());
        }

        if (movement.x == -1f)
        {
            Walking = true;
            Right.enabled = true;
            Left.enabled = false;
            Forward.enabled = false;
            Backwards.enabled = false;
        }
        if (movement.x == 1f)
        {
            Walking = true;
            Left.enabled = true;
            Right.enabled = false;
            Forward.enabled = false;
            Backwards.enabled = false;
        }
        if (movement.y == -1f)
        {
            Walking = true;
            Right.enabled = false;
            Left.enabled = false;
            Forward.enabled = true;
            Backwards.enabled = false;
        }
        if (movement.y == 1f)
        {
            Walking = true;
            Right.enabled = false;
            Left.enabled = false;
            Forward.enabled = false;
            Backwards.enabled = true;
        }
        if (movement.x == 0 && movement.y == 0)
        {
            Walking = false;
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
        attacking = true;
        Walking = false;
        Forwardanimator.SetTrigger("Attack");
        Backanimator.SetTrigger("Attack");
        Leftanimator.SetTrigger("Attack");
        Rightanimator.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
        attacking = false;
        Walking = true;
    }
}
