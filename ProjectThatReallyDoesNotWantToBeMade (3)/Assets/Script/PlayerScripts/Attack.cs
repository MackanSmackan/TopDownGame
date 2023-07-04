using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] Movement movScript;
    [SerializeField] Transform NewTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.GetComponent<EnemyHandler>() != null && movScript.attacking)
        {
            collision.GetComponent<EnemyHandler>().TakeDamage(this.transform, NewTarget);
            
        }
    }

    
}