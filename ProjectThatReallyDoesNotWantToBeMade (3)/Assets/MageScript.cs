using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageScript : MonoBehaviour
{
    [Header("Things to spawn")]
    [SerializeField] GameObject Totem;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject BouncyBalls;

    [Header("Transforms for random placement")]
    [SerializeField] Transform MaxPos;
    [SerializeField] Transform MinPos;

    [Header("Other stuff")]
    [SerializeField] float JumpTime;
    [SerializeField] int Health;
    [SerializeField] int MaxTimesAttacked;
    [SerializeField] int TimesAttacked;
    float invis;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (TimesAttacked >= MaxTimesAttacked)
        {
            Jump();
            TimesAttacked = 0;
        }
        else
        {
            if (collision.gameObject.name == "bone_12")
            {
                Health--;
                TimesAttacked++;
            }
        }
    }

    void Jump()
    {
        print("Jump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("JaJa");
    }
}
