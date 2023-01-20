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
        invis = true;
        Vector3 Randompoint = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x), 0, Random.Range(MinPos.position.y, MaxPos.position.y));
        GameObject enemy1 = Instantiate(Enemy, Randompoint, this.transform.rotation);
        enemy1.GetComponent<FollowPlayer>().Targetposition = player;
        yield return new WaitForSeconds(0.5f);

        Randompoint = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x), 0, Random.Range(MinPos.position.y, MaxPos.position.y));
        GameObject enemy2 = Instantiate(Enemy, Randompoint, this.transform.rotation);
        enemy2.GetComponent<FollowPlayer>().Targetposition = player;
        yield return new WaitForSeconds(0.5f);

        Randompoint = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x), 0, Random.Range(MinPos.position.y, MaxPos.position.y));
        GameObject enemy3 = Instantiate(Enemy, Randompoint, this.transform.rotation);
        enemy3.GetComponent<FollowPlayer>().Targetposition = player;
        yield return new WaitForSeconds(5f);
        invis = false;
    }

    void SpawnTotem()
    {
        Vector3 Randompoint = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x), 0, Random.Range(MinPos.position.y, MaxPos.position.y));
        GameObject totem = Instantiate(Totem, Randompoint, this.transform.rotation);
        Vector3 OtherRandomPoint = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x), 0, Random.Range(MinPos.position.y, MaxPos.position.y));
        totem.transform.position = Vector3.Lerp(Randompoint, this.transform.position, 5);
    }
}
