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
            collision.gameObject.GetComponent<CompleteEnemyMovement>().TakeDamage(AttackPower);
            StartCoroutine(DisableMove(collision.gameObject));
        }
    }

    IEnumerator DisableMove(GameObject col)
    {
        col.GetComponent<CompleteEnemyMovement>().enabled = false;
        col.gameObject.GetComponent<CompleteEnemyMovement>().rb.velocity = Vector2.zero;
        if(Up.enabled)
        {
            col.gameObject.GetComponent<CompleteEnemyMovement>().rb.AddForce(Vector2.up * strength);
        }
        else if (Right.enabled)
        {
            col.gameObject.GetComponent<CompleteEnemyMovement>().rb.AddForce(Vector2.right * strength);
        }
        else if (Down.enabled)
        {
            col.gameObject.GetComponent<CompleteEnemyMovement>().rb.AddForce(Vector2.down * strength);
        }
        else
        {
            col.gameObject.GetComponent<CompleteEnemyMovement>().rb.AddForce(Vector2.left * strength);
        }
        yield return new WaitForSeconds(1f);
        col.GetComponent<CompleteEnemyMovement>().enabled = true;
    }
}