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
            Enemy.GetComponent<FollowPlayer>().enabled = true;
        }
    }
    public void EndAttack()
    {
        foreach (GameObject Enemy in Enemies)
        {
            print(Enemy);
            Enemy.GetComponent<FollowPlayer>().enabled = false;
            Enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
