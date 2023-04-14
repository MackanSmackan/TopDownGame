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
    bool Damaged;
    public bool Died;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !Died && !Damaged)
        {
            StartCoroutine(TakeDamageTrigger(collision));
        }
    }

    IEnumerator TakeDamageTrigger(Collider2D col)
    {
        col.gameObject.GetComponent<Health>().health--;
        Damaged = true;
        yield return new WaitForSeconds(0.2f);
        Damaged = false;
    }
    IEnumerator TakeDamageCollision(Collision2D col)
    {
        col.gameObject.GetComponent<Health>().health--;
        Damaged = true;
        yield return new WaitForSeconds(0.2f);
        Damaged = false;
    }
}
