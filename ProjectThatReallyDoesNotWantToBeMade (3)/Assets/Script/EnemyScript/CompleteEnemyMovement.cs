using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteEnemyMovement : MonoBehaviour
{
    [Header("Team")]
    public Transform target;

    [Header("Loot")]
    [SerializeField] GameObject Loot1;
    [SerializeField] GameObject Loot2;

    [Header("Variables")]
    [SerializeField] Animator Cam;
    [SerializeField] Rigidbody2D rb;
    public int Health;
    public int Damage;
    public float Speed;
    bool Damaged;


    enum Enemytype { Goblin, GhostOrb };
    [Header("Enemy type")]
    [SerializeField] Enemytype enemyType;



    [Header("Ghost orb only")]
    [SerializeField] float LoungeSpeed;
    [SerializeField] float LoungeDistance;
    [SerializeField] float LoungePower;
    [SerializeField] float BaseSpeed;
    [SerializeField] Animator Animator;
    Vector2 dir;
    bool CanTurnLeft = false;
    bool CanTurnRight = true;

    [Header("Goblin only")]
    [SerializeField] bool spinDirection;
    [SerializeField] float Radius;
    [SerializeField] float CircleSpeed;
    float CurrentStep;

    Vector3 CirclePos;


    [SerializeField] Animator animatorD;
    [SerializeField] Animator AnimatorR;
    [SerializeField] Animator animatorU;
    [SerializeField] Animator AnimatorL;

    [SerializeField] SpriteRenderer Up;
    [SerializeField] SpriteRenderer Down;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] SpriteRenderer Right;

    private void FixedUpdate()
    {
        // Goblin
        if (enemyType == Enemytype.Goblin)
        {
            //Look at the Player
            float xDir = Mathf.Abs(this.transform.position.x - target.position.x);
            float yDir = Mathf.Abs(this.transform.position.y - target.position.y);
            if (xDir < yDir)
            {
                AnimatorL.SetFloat("x", 0);
                AnimatorR.SetFloat("x", 0);
                if (this.transform.position.y < target.position.y)
                {
                    animatorU.SetFloat("y", 1);
                    Up.enabled = true;
                    Down.enabled = false;
                    Left.enabled = false;
                    Right.enabled = false;
                }
                else
                {
                    animatorD.SetFloat("y", -1);
                    Up.enabled = false;
                    Down.enabled = true;
                    Left.enabled = false;
                    Right.enabled = false;
                }
            }
            else
            {
                animatorU.SetFloat("y", 0);
                animatorD.SetFloat("y", 0);
                if (this.transform.position.x < target.position.x)
                {
                    AnimatorR.SetFloat("x", 1);
                    Up.enabled = false;
                    Down.enabled = false;
                    Left.enabled = false;
                    Right.enabled = true;
                }
                else
                {
                    AnimatorL.SetFloat("x", -1);
                    Up.enabled = false;
                    Down.enabled = false;
                    Left.enabled = true;
                    Right.enabled = false;
                }
            }


            if (CircleSpeed >= CurrentStep)
            {
                DrawCircle();
            }
            else
            {

                CurrentStep = 0;
                StartCoroutine(goblinAttack());
            }

            rb.velocity = (CirclePos - this.transform.position).normalized * Speed;
        }

        else if (enemyType == Enemytype.GhostOrb)
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
                Animator.SetTrigger("Left");
                Animator.SetBool("IsRight", false);
                CanTurnLeft = false;
                CanTurnRight = true;
            }
            if (this.transform.position.x <= target.position.x && CanTurnRight)
            {
                Animator.SetTrigger("Right");
                Animator.SetBool("IsRight", true);
                CanTurnLeft = true;
                CanTurnRight = false;
            }


            rb.velocity = dir * Speed;

        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Cam.Play("CameraShake");
            this.gameObject.GetComponent<CompleteEnemyMovement>().enabled = false;
            int RN = Random.Range(-1, 2);
            if (RN <= 0)
            {
                Instantiate(Loot1, this.transform.position, this.transform.rotation);
            }
            else
            {
                Instantiate(Loot2, this.transform.position, this.transform.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyType == Enemytype.GhostOrb)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Movement>().attacking == false)
            {
                collision.gameObject.GetComponent<Health>().health -= Damage;
            }
        }
    }

    // Goblin stuff;
    void DrawCircle()
    {
        float Progress = CurrentStep / CircleSpeed;
        float thisRad = Progress * 2 * Mathf.PI;

        float Xscale = Mathf.Cos(thisRad);
        float Yscale = Mathf.Sin(thisRad);

        if (spinDirection)
        {
            CirclePos = new Vector3(-Xscale * Radius, -Yscale * Radius, 0) + target.position;
        }
        else
        {
            CirclePos = new Vector3(Xscale * Radius, Yscale * Radius, 0) + target.position;
        }
        CurrentStep += Time.deltaTime;
    }

    IEnumerator goblinAttack()
    {
        float oldRad = Radius;
        Radius = 1.8f;
        yield return new WaitForSeconds(1);
        Radius = oldRad;
    }
}
