using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGhost : MonoBehaviour
{
    [SerializeField] Vector4 HurtColor;
    [SerializeField] Movement movScript;
    float strength = 2;

    IEnumerator Died(GameObject col)
    {
        col.gameObject.GetComponent<FollowPlayer>().enabled = false;
        col.GetComponent<Animator>().SetTrigger("Died");
        yield return new WaitForSeconds(1f);
        Destroy(col);
        this.gameObject.GetComponentInParent<Inventory>().riksdaler++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.GetComponent<FollowPlayer>() != null && movScript.attacking)
        {
            if (collision.gameObject.GetComponent<FollowPlayer>().GhostHealth <= 0)
            {
                StartCoroutine(Died(collision.gameObject));
            }
            else
            {
                Vector2 dir = new Vector2(10, 1);
                dir.Normalize();
                StartCoroutine(DisableMove(collision.gameObject));
                
                collision.GetComponent<Rigidbody2D>().velocity = dir * strength;

                collision.gameObject.GetComponent<FollowPlayer>().GhostHealth--;
            }
        }
    }

    IEnumerator DisableMove(GameObject col)
    {
        col.GetComponent<Animator>().enabled = false;
        col.GetComponent<FollowPlayer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        col.GetComponent<FollowPlayer>().enabled = true;
        col.GetComponent<Animator>().enabled = true;
    }
}