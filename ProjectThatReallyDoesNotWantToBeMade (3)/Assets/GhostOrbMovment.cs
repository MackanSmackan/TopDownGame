using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostOrbMovment : MonoBehaviour
{
    [SerializeField] GhostOrbObject GhostValues;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Transform target;
    public bool Pause;
    Vector2 dir;
    float Speed;
    int Damage;

    float LoungeSpeed;
    float LoungeDistance;
    float LoungePower;
    float BaseSpeed;

    bool CanTurnLeft = false;
    bool CanTurnRight = true;

    // Start is called before the first frame update
    void Start()
    {
        LoungeDistance = GhostValues.LoungeDistance;
        LoungeSpeed = GhostValues.LoungeSpeed;
        BaseSpeed = GhostValues.BaseSpeed;
        Speed = GhostValues.Speed;
        Damage = GhostValues.Damage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) > LoungeDistance)
        {
            Speed = BaseSpeed;
            dir = target.position - this.transform.position;
            dir.Normalize();
        }
        else
        {
            Speed = LoungeSpeed;
        }

        if (this.transform.position.x >= target.position.x && CanTurnLeft)
        {
            animator.SetTrigger("Left");
            animator.SetBool("IsRight", false);
            CanTurnLeft = false;
            CanTurnRight = true;
        }
        if (this.transform.position.x <= target.position.x && CanTurnRight)
        {
            animator.SetTrigger("Right");
            animator.SetBool("IsRight", true);
            CanTurnLeft = true;
            CanTurnRight = false;
        }


        rb.velocity = dir * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Movement>().attacking == false)
        {
            collision.gameObject.GetComponent<Health>().health -= Damage;
        }
    }
}
