using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGhost : MonoBehaviour
{
    GameObject DDoL;
    int AttackPower = 1;
    [SerializeField] Vector4 HurtColor;
    [SerializeField] Movement movScript;
    [SerializeField] GameObject Shard;
    [SerializeField] GameObject Heart;
    float strength = 2;
    IEnumerator Died(GameObject col)
    {
        col.gameObject.GetComponent<FollowPlayer>().enabled = false;
        col.GetComponent<Animator>().SetTrigger("Died");
        yield return new WaitForSeconds(1f);
        int RN = Random.Range(-1, 2);
        print(RN);
        if (RN <= 0)
        {
            Instantiate(Shard, col.transform.position, col.transform.rotation);
        }
        else
        {
            Instantiate(Heart, col.transform.position, col.transform.rotation);
        }
        Destroy(col);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.GetComponent<FollowPlayer>() != null && movScript.attacking)
        {
            {
                if (collision.GetComponent<FollowPlayer>().Died == false)
                {
                    Vector2 dir = collision.transform.position - this.transform.parent.parent.parent.position;
                    dir.Normalize();
                    StartCoroutine(DisableMoveGhost(collision.gameObject));

                    collision.GetComponent<Rigidbody2D>().velocity = dir * strength;

                    collision.gameObject.GetComponent<FollowPlayer>().GhostHealth = collision.gameObject.GetComponent<FollowPlayer>().GhostHealth - AttackPower;
                    if (collision.gameObject.GetComponent<FollowPlayer>().GhostHealth <= 0 && collision.GetComponent<FollowPlayer>().Died == false)
                    {
                        StartCoroutine(Died(collision.gameObject));
                        collision.GetComponent<FollowPlayer>().Died = true;
                    }
                }
            }
        }
        else if (collision.gameObject.GetComponent<GoblinFollowPlayer>() != null && movScript.attacking)
        {
            if (!collision.gameObject.GetComponent<GoblinFollowPlayer>().died && movScript.attacking)
            {
                collision.gameObject.GetComponent<GoblinFollowPlayer>().Health = collision.gameObject.GetComponent<GoblinFollowPlayer>().Health - AttackPower;
                Vector2 dir = collision.transform.position - this.transform.parent.parent.parent.position;
                dir.Normalize();
                collision.GetComponent<Rigidbody2D>().velocity = dir * strength;
                if (collision.gameObject.GetComponent<GoblinFollowPlayer>().Health <= 0)
                {
                    collision.gameObject.GetComponent<GoblinFollowPlayer>().Die();
                }
            }
        }
    }

    IEnumerator DisableMoveGhost(GameObject col)
    {
        col.GetComponent<Animator>().enabled = false;
        col.GetComponent<FollowPlayer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        col.GetComponent<FollowPlayer>().enabled = true;
        col.GetComponent<Animator>().enabled = true;
    }
}