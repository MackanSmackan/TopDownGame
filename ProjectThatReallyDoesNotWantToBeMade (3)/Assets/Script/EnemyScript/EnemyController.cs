using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;
    [SerializeField] GameObject[] Goblins;
    [SerializeField] MusicScript musScript;

    public void StartAttack()
    {
        foreach (GameObject Enemy in Enemies)
        {
            if (Enemy != null)
            {
                musScript.AddEnemy();
                Enemy.GetComponent<FollowPlayer>().enabled = true;
            }
        }

        foreach (GameObject goblin in Goblins)
        {
            if (goblin != null)
            {
                musScript.AddEnemy();
                goblin.GetComponent<GoblinFollowPlayer>().enabled = true;
            }
        }
    }
    public void EndAttack()
    {
        foreach (GameObject Enemy in Enemies)
        {
            if (Enemy != null)
            {
                musScript.RemoveEnemy();
                Enemy.GetComponent<FollowPlayer>().enabled = false;
                Enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        foreach (GameObject goblin in Goblins)
        {
            if (goblin != null)
            {
                musScript.RemoveEnemy();
                goblin.GetComponent<GoblinFollowPlayer>().enabled = false;
                goblin.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
