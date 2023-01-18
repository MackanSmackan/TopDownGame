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
                collision.gameObject.GetComponent<FollowPlayer>().GhostHealth--;
            }
        }
    }
}