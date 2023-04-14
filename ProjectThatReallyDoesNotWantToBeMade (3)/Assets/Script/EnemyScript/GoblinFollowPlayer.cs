using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFollowPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float DetectDistance;
    [SerializeField] float CircleDistance;
    [SerializeField] float Radius;
    [SerializeField] float Steps;
    float CurrentStep;

    float xDir;
    float yDir;
    Transform Player;
    Vector3 TargetPos;

    [SerializeField] Animator animatorD;
    [SerializeField] Animator AnimatorR;
    [SerializeField] Animator animatorU;
    [SerializeField] Animator AnimatorL;

    [SerializeField] SpriteRenderer Up;
    [SerializeField] SpriteRenderer Down;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] SpriteRenderer Right;



    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        xDir = Mathf.Abs(this.transform.position.x - Player.position.x);
        yDir = Mathf.Abs(this.transform.position.y - Player.position.y);
        //Look at the Player
        if (xDir < yDir)
        {
            AnimatorL.SetFloat("x", 0);
            AnimatorR.SetFloat("x", 0);
            if (this.transform.position.y < Player.position.y)
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
            if (this.transform.position.x < Player.position.x)
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
        
        if (Steps >= CurrentStep)
        {
            DrawCircle();
        }
        else
        {
            CurrentStep = 0;
        }

        rb.velocity = TargetPos - this.transform.position;
    }

    void DrawCircle()
    {
        float Progress = CurrentStep / Steps;
        float thisRad = Progress * 2 * Mathf.PI;

        float Xscale = Mathf.Cos(thisRad);
        float Yscale = Mathf.Sin(thisRad);

        TargetPos = new Vector3(Xscale * Radius, Yscale * Radius, 0) + Player.position;
        CurrentStep += Time.deltaTime;
    }
}
