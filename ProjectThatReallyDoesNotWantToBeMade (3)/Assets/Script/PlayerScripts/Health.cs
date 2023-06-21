using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    [SerializeField] int numOfHearts;
    [SerializeField] SpriteRenderer Forward;
    [SerializeField] SpriteRenderer Back;
    [SerializeField] SpriteRenderer Left;
    [SerializeField] SpriteRenderer Right;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Animator animator;
    [SerializeField] Movement movement;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] AudioSource DeathMusicn;
    bool Died;
    public Image[] hearts;
    public bool IsAttacking;

    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0 && !Died)
        {
            StartCoroutine(Die());
        }

    }

    IEnumerator Die()
    {
        Forward.enabled = true;
        Left.enabled = false;
        Back.enabled = false;
        Right.enabled = false;
        Died = true;
        movement.enabled = false;
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        DeathMusicn.Play();
        DeathScreen.active = true;
    }
}
