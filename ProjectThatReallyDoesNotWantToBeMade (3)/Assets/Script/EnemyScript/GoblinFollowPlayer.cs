using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFollowPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    float xDir;
    float yDir;
    Transform Player;
    [SerializeField] Animator animatorD;
    [SerializeField] Animator AnimatorR;
    [SerializeField] Animator animatorU;
    [SerializeField] Animator AnimatorL;
    //Lol DRUL = drool
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
        transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
    }
}
