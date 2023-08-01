using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovment : MonoBehaviour
{
    enum State { idle, angry};

    //Targeting
    [Header("Detection")]
    [SerializeField] Transform LookFor;
    Vector3 TargetPos;
    public Transform AngryAt;
    [SerializeField] State Currentstate;
    [SerializeField] GameObject Alerted;

    [Header("Movement")]
    [SerializeField] GoblinObject values;
    [SerializeField] Rigidbody2D rb;
    float Speed;
    int Damage;

    [Header("Visible rig")]
    public Animator animatorD;
    public Animator AnimatorR;
    public Animator animatorU;
    public Animator AnimatorL;

    [SerializeField] SpriteRenderer Up;
    [SerializeField] SpriteRenderer Down;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] SpriteRenderer Right;

    [SerializeField] Transform MaxPos;
    [SerializeField] Transform MinPos;

    public bool Pause;
    public bool CanDetect = true;
    RaycastHit2D hit;

    //Running around
    float Radius;
    float CircleSpeed;
    bool spinDirection;

    float CurrentStep;
    Vector3 CirclePos;


    // Start is called before the first frame update
    void Start()
    {
        Speed = values.Speed;
        Radius = values.Radius;
        CircleSpeed = values.CircleSpeed;
        spinDirection = values.SpinDirection;
        Damage = values.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentstate == State.angry)
        {
            TargetPos = AngryAt.position;
            //Look at the Player
            float xDir = Mathf.Abs(this.transform.position.x - TargetPos.x);
            float yDir = Mathf.Abs(this.transform.position.y - TargetPos.y);
            if (xDir < yDir)
            {
                AnimatorL.SetFloat("x", 0);
                AnimatorR.SetFloat("x", 0);
                if (this.transform.position.y < TargetPos.y)
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
                if (this.transform.position.x < TargetPos.x)
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

            if (CircleSpeed >= CurrentStep && CurrentStep != 180)
            {
                DrawCircle();
            }
            else
            {
                CurrentStep = 0;
                StartCoroutine(GoblinAttack());
            }

            if (!Pause)
            {
                rb.velocity = (CirclePos - this.transform.position).normalized * Speed;
            }
        }
        else if (Currentstate == State.idle)
        {


            if (Vector2.Distance(this.transform.position, TargetPos) < 1)
            {
                StartCoroutine(GetNewIdlePos());
            }
            else
            {
                if (!Pause)
                {
                    //Look at the Player
                    float xDir = Mathf.Abs(this.transform.position.x - TargetPos.x);
                    float yDir = Mathf.Abs(this.transform.position.y - TargetPos.y);
                    if (xDir < yDir)
                    {
                        AnimatorL.SetFloat("x", 0);
                        AnimatorR.SetFloat("x", 0);
                        if (this.transform.position.y < TargetPos.y)
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
                        if (this.transform.position.x < TargetPos.x)
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

                    rb.velocity = (TargetPos - this.transform.position).normalized * Speed / 2;
                }
            }

            DetectPlayer();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Movement>().attacking == false)
            {
                if (Up.enabled == true)
                {
                    animatorU.SetTrigger("AttackBackward");
                }
                else if (Right.enabled == true)
                {
                    AnimatorR.SetTrigger("AttackRight");
                }
                else if (Down.enabled == true)
                {
                    animatorD.SetTrigger("AttackForward");
                }
                else
                {
                    AnimatorL.SetTrigger("AttackLeft");
                }
                collision.gameObject.GetComponent<Health>().health -= Damage;
            }
    }

    void DrawCircle()
    {
        float Progress = CurrentStep / CircleSpeed;
        float thisRad = Progress * 2 * Mathf.PI;

        float Xscale = Mathf.Cos(thisRad);
        float Yscale = Mathf.Sin(thisRad);

        if (spinDirection)
        {
            CirclePos = new Vector3(-Xscale * Radius, -Yscale * Radius, 0) + TargetPos;
        }
        else
        {
            CirclePos = new Vector3(Xscale * Radius, Yscale * Radius, 0) + TargetPos;
        }
        CurrentStep += Time.deltaTime;
    }

    IEnumerator GoblinAttack()
    {
        float oldRad = Radius;
        Radius = 0f;
        yield return new WaitForSeconds(1f);
        Radius = oldRad;
    }

    IEnumerator GetNewIdlePos()
    {
        TargetPos.x = Random.Range(MaxPos.position.x, MinPos.position.x);
        TargetPos.y = Random.Range(MaxPos.position.y, MinPos.position.y);
        Pause = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        Pause = false;
    }

    public void DetectPlayer()
    {
        if (Vector2.Dot((TargetPos - this.transform.position), (LookFor.transform.position - this.transform.position)) > -0f && Vector2.Distance(LookFor.position, this.transform.position) < 5)
        {
            AngryAt = LookFor;
            Instantiate(Alerted, this.transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
            BecomeAware();
        }
        
    }

    public void BecomeAware()
    {
        Currentstate = State.angry;
    }
}
