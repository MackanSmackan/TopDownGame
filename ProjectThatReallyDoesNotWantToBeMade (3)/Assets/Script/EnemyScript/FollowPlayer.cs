using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Ghost;
    bool CanTurnLeft = false;
    bool CanTurnRight = true;
    bool IsRight;
    [SerializeField] Animator Animator;
    [SerializeField] float speed;
    [SerializeField] Transform Targetposition;

    public int GhostHealth;

    void Update()
    {

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

        transform.position = Vector2.MoveTowards(transform.position, Targetposition.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Health>().health--;
        }
    }
}
