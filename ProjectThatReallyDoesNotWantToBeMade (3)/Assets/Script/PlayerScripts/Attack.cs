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
    float strength = 2;


    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.GetComponent<CompleteEnemyMovement>() != null && movScript.attacking)
        {
            collision.gameObject.GetComponent<CompleteEnemyMovement>().TakeDamage(AttackPower);
            DisableMove(collision.gameObject);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - this.transform.position).normalized * strength);
        }
    }

    IEnumerator DisableMove(GameObject col)
    {
        col.GetComponent<CompleteEnemyMovement>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        col.GetComponent<CompleteEnemyMovement>().enabled = true;
    }
}