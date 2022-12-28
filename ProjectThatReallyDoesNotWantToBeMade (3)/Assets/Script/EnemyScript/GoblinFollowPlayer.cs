using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFollowPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    float x;
    float y;
    Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
    }
}
