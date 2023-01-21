using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÁttackGhost : MonoBehaviour
{
    [SerializeField] Vector4 HurtColor;
    [SerializeField] Movement movScript;
    bool KnockBacking;
    GameObject enemy;
    Vector3 dire;

    IEnumerator Died(GameObject col)
    {
        col.gameObject.GetComponent<FollowPlayer>().enabled = false;
        col.GetComponent<Animator>().SetTrigger("Died");
        yield return new WaitForSeconds(0.4f);
        Destroy(col);
    }

    private void Update()
    {
        if (KnockBacking)
        {
            MoveKnockBack(dire, enemy);
        }
    }

    IEnumerator Knockback(Vector3 dir, GameObject Ghost)
    {
        Ghost.GetComponent<FollowPlayer>().enabled = false;
        KnockBacking = true;
        enemy = Ghost.gameObject;
        dire = dir;
        yield return new WaitForSeconds(1);
        KnockBacking = false;
        Ghost.GetComponent<FollowPlayer>().enabled = true;
    }
    void MoveKnockBack(Vector3 direction, GameObject Ghost)
    {
        direction.Normalize();
        Debug.DrawRay(Vector3.zero, direction);
        Ghost.transform.position = Vector3.Lerp(enemy.transform.position, direction * 0.75f, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy = collision.gameObject; 
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