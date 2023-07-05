using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    enum Type { Goblin, GhostOrb};

    [SerializeField] GoblinObject GoblinValues;
    [SerializeField] GhostOrbObject GhostOrbValues;

    int Health;
    [SerializeField] Type type;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        if (type == Type.Goblin)
        {
            Health = GoblinValues.Health;
        }
        else if (type == Type.GhostOrb)
        {
            Health = GhostOrbValues.Health;
        }
    }

    public void TakeDamage(Transform HitFrom, Transform Target)
    {
        Health -= 1;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (type == Type.Goblin)
        {
            StopAllCoroutines();
            StartCoroutine(KnockBackGoblin(HitFrom, Target));
        }
        else if (type == Type.GhostOrb)
        {
            StopAllCoroutines();
            StartCoroutine(KnockbackGhostOrb(HitFrom, Target));
        }
    }

    IEnumerator KnockBackGoblin(Transform HitFrom, Transform Target)
    {
        print("HitGoblin");
        this.GetComponent<GoblinMovment>().Pause = true;
        this.GetComponent<GoblinMovment>().AngryAt = Target;
        this.GetComponent<GoblinMovment>().BecomeAware();
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(this.transform.position.x - HitFrom.position.x, this.transform.position.y - HitFrom.position.y).normalized * 4, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5F);
        this.GetComponent<GoblinMovment>().Pause = false;
    }

    IEnumerator KnockbackGhostOrb(Transform HitFrom, Transform Target)
    {
        this.GetComponent<GhostOrbMovment>().Pause = true;

        this.GetComponent<Animator>().enabled = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(this.transform.position.x - HitFrom.position.x, this.transform.position.y - HitFrom.position.y).normalized * 4, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<GhostOrbMovment>().Pause = false;
    }
}
