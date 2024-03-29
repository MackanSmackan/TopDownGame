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

    [Header("Other scripts")]
    [SerializeField] Movement mov;

    [Header("Jump and health")]
    [SerializeField] float JumpTime;
    [SerializeField] int Health;
    [SerializeField] int MaxTimesAttacked;
    [SerializeField] int TimesAttacked;
    [SerializeField] Transform player;
    bool invis;

    void Jump()
    {
        Vector2 Randompoint = new Vector2(Random.Range(MinPos.position.x, MaxPos.position.x), Random.Range(MinPos.position.y, MaxPos.position.y));
        this.transform.position = Randompoint;
        Health--;
        TimesAttacked = 0;
        StartAttack();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TimesAttacked >= MaxTimesAttacked)
        {
            Jump();
        }
        else
        {
            if (other.gameObject.name == "bone_12" && mov.attacking && !invis)
            {
                TimesAttacked++;
            }
        }
    }

    void StartAttack()
    {
        int randomnumber = Random.Range(1, 3);
        

        if (randomnumber == 1)
        {
            StartCoroutine(SpawnGhosts());
        }
        if (randomnumber == 2)
        {
            SpawnTotem();
        }
        if (randomnumber == 3)
        {
            print("Spawn balls");
        }
    }

    IEnumerator SpawnGhosts()
    {
        print("Spawn ghosts or someting");
        yield return new WaitForSeconds(2);
        print("FIX IT");
    }

    void SpawnTotem()
    {
        Vector3 Randompoint = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x), 0, Random.Range(MinPos.position.y, MaxPos.position.y));
        GameObject totem = Instantiate(Totem, Randompoint, this.transform.rotation);
        totem.GetComponent<LaserBeamAttack>().MinPos = MinPos;
        totem.GetComponent<LaserBeamAttack>().MaxPos = MaxPos;
        totem.GetComponent<LaserBeamAttack>().HasTransforms = true;
    }
}
