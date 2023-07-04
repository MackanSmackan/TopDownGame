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
            StartCoroutine(KnockBackGoblin(HitFrom, Target));
        }
        else if (type == Type.GhostOrb)
        {
            StartCoroutine(KnockbackGhostOrb(HitFrom, Target));
        }
    }

    IEnumerator KnockBackGoblin(Transform HitFrom, Transform Target)
    {
        this.GetComponent<GoblinMovment>().Pause = true;
        this.GetComponent<GoblinMovment>().AngryAt = Target;
        this.GetComponent<GoblinMovment>().BecomeAware();
        rb.AddForce(new Vector2(this.transform.position.x - HitFrom.position.x, this.transform.position.y - HitFrom.position.y).normalized * 2, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        this.GetComponent<GoblinMovment>().Pause = false;
    }

    IEnumerator KnockbackGhostOrb(Transform HitFrom, Transform Target)
    {
        this.GetComponent<GhostOrbMovment>().Pause = true;
        rb.AddForce(new Vector2(this.transform.position.x - HitFrom.position.x, this.transform.position.y - HitFrom.position.y).normalized * 2, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        this.GetComponent<GhostOrbMovment>().Pause = false;
    }
}
