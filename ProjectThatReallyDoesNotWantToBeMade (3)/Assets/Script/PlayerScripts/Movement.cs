using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] SpriteRenderer Forward;
    [SerializeField] SpriteRenderer Backwards;
    [SerializeField] SpriteRenderer Right;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] Animator Leftanimator;
    [SerializeField] Animator Forwardanimator;
    [SerializeField] Animator Rightanimator;
    [SerializeField] Animator Backanimator;
    public bool attacking;


    [SerializeField] Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        Forwardanimator.SetFloat("HorizontalSpeed", movement.x);
        movement.y = Input.GetAxisRaw("Vertical");
        Forwardanimator.SetFloat("VerticalSpeed", movement.y);

        Leftanimator.SetFloat("HorizontalSpeed", movement.x);
        Leftanimator.SetFloat("VerticalSpeed", movement.y);

        Rightanimator.SetFloat("HorizontalSpeed", movement.x);
        Rightanimator.SetFloat("VerticalSpeed", movement.y);

        Backanimator.SetFloat("HorizontalSpeed", movement.x);
        Backanimator.SetFloat("VerticalSpeed", movement.y);



        if (movement.x == -1f && Leftanimator.GetCurrentAnimatorStateInfo(0).IsName("LeftWalk"))
        {
            Right.enabled = true;
            Left.enabled = false;
            Forward.enabled = false;
            Backwards.enabled = false;
        }
        if (movement.x == 1f && Rightanimator.GetCurrentAnimatorStateInfo(0).IsName("RightWalking"))
        {
            Left.enabled = true;
            Right.enabled = false;
            Forward.enabled = false;
            Backwards.enabled = false;
        }
        if (movement.y == -1f && Forwardanimator.GetCurrentAnimatorStateInfo(0).IsName("ForwardWalking"))
        {
            Right.enabled = false;
            Left.enabled = false;
            Forward.enabled = true;
            Backwards.enabled = false;
        }
        if (movement.y == 1f && Backanimator.GetCurrentAnimatorStateInfo(0).IsName("Backwards"))
        {
            Right.enabled = false;
            Left.enabled = false;
            Forward.enabled = false;
            Backwards.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Forward.isVisible)
        {
            StartCoroutine(Attacking());
            Forwardanimator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Left.isVisible)
        {
            StartCoroutine(Attacking());
            Leftanimator.SetTrigger("LeftAttack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Right.isVisible)
        {
            StartCoroutine(Attacking());
            Rightanimator.SetTrigger("RightAttack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Backwards.isVisible)
        {
            StartCoroutine(Attacking());
            Backanimator.SetTrigger("BackAttack");
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Attacking()
    {
        attacking = true;
        yield return new WaitForSeconds(3);
        attacking = false;
    }
}
