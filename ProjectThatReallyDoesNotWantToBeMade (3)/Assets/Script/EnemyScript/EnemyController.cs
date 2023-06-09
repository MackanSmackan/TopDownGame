using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;

    public void StartAttack()
    {
        foreach (GameObject Enemy in Enemies)
        {
            if (Enemy != null)
            {
                Enemy.GetComponent<CompleteEnemyMovement>().enabled = true;
            }
        }
    }
    public void EndAttack()
    {
        foreach (GameObject Enemy in Enemies)
        {
            if (Enemy != null)
            {
                Enemy.GetComponent<CompleteEnemyMovement>().enabled = false;
                Enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
