using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Ghost;
    bool CanTurnLeft = false;
    bool CanTurnRight = true;
    [SerializeField] Animator Animator;
    [SerializeField] float speed;
    public Transform Targetposition;

    public int GhostHealth;

    void FixedUpdate()
    {
        Vector2 dir = Targetposition.position - this.transform.position;
        dir.Normalize();
        if (Ghost.transform.position.x >= Targetposition.position.x && CanTurnLeft)
        {
            Animator.SetTrigger("Left");
            Animator.SetBool("IsRight", false);
            CanTurnLeft = false;
            CanTurnRight = true;
        }
        if (Ghost.transform.position.x <= Targetposition.position.x && CanTurnRight)
        {
            Animator.SetTrigger("Right");
            Animator.SetBool("IsRight", true);
            CanTurnLeft = true;
            CanTurnRight = false;
        }

        Ghost.GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Health>().health--;
        }
    }
}
