using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject DDoL;
    int AttackPower = 1;
    [SerializeField] Animator Cam;
    [SerializeField] Movement movScript;
    [SerializeField] GameObject Shard;
    [SerializeField] GameObject Heart;
    [SerializeField] float strength = 2;
    [SerializeField] SpriteRenderer Up;
    [SerializeField] SpriteRenderer Down;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] SpriteRenderer Right;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.GetComponent<CompleteEnemyMovement>() != null && movScript.attacking)
        {
            Vector2 dir = collision.transform.position - this.transform.parent.parent.parent.position;
            dir.Normalize();
            collision.gameObject.GetComponent<CompleteEnemyMovement>().TakeDamage(AttackPower);
            StartCoroutine(DisableMove(collision.gameObject));
            collision.gameObject.GetComponent<CompleteEnemyMovement>().rb.velocity = dir * AttackPower;
        }
    }

    IEnumerator DisableMove(GameObject col)
    {


        if (col.GetComponent<CompleteEnemyMovement>().Animator != null)
        {
            col.GetComponent<CompleteEnemyMovement>().Animator.enabled = false;
        }
        else
        {
            col.GetComponent<CompleteEnemyMovement>().animatorD.enabled = false;
            col.GetComponent<CompleteEnemyMovement>().AnimatorR.enabled = false;
            col.GetComponent<CompleteEnemyMovement>().animatorU.enabled = false;
            col.GetComponent<CompleteEnemyMovement>().AnimatorL.enabled = false;
        }

        col.GetComponent<CompleteEnemyMovement>().enabled = false;
        col.gameObject.GetComponent<CompleteEnemyMovement>().rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        if (col != null)
        {
            col.GetComponent<CompleteEnemyMovement>().enabled = true;
            if (col.GetComponent<CompleteEnemyMovement>().Animator != null)
            {
                col.GetComponent<CompleteEnemyMovement>().Animator.enabled = true;
            }
            else
            {
                col.GetComponent<CompleteEnemyMovement>().animatorD.enabled = true;
                col.GetComponent<CompleteEnemyMovement>().AnimatorR.enabled = true;
                col.GetComponent<CompleteEnemyMovement>().animatorU.enabled = true;
                col.GetComponent<CompleteEnemyMovement>().AnimatorL.enabled = true;
            }
        }
    }
}