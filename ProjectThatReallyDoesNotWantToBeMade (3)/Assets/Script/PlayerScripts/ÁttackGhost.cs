using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÁttackGhost : MonoBehaviour
{
    [SerializeField] Vector4 HurtColor;
    [SerializeField] Movement movScript;

    IEnumerator Died(GameObject col)
    {
        col.gameObject.GetComponent<FollowPlayer>().enabled = false;
        col.GetComponent<Animator>().SetTrigger("Died");
        yield return new WaitForSeconds(0.4f);
        Destroy(col);
    }

    IEnumerator Knockback(Vector3 dir, GameObject Ghost)
    {
        Ghost.GetComponent<FollowPlayer>().enabled = false;
        Ghost.transform.position = Vector3.MoveTowards(Ghost.transform.position, dir * 2, 1f);
        yield return new WaitForSeconds(1);

        Ghost.GetComponent<FollowPlayer>().enabled = true;
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
                Vector3 dir = collision.transform.position - this.transform.position;
                dir.Normalize();

                StartCoroutine(Knockback(dir, collision.gameObject));
                
                collision.gameObject.GetComponent<FollowPlayer>().GhostHealth--;
            }
        }
    }
}