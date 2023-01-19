using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamAttack : MonoBehaviour
{
    [SerializeField] Transform Box;
    [SerializeField] float DegreesPerSecond;
    [SerializeField] Transform Effect;
    [SerializeField] LayerMask Mask;
    float invis;
    [SerializeField] float TimeToStayAlive;
    float timeAlive;

    private void Awake()
    {
        invis = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAlive >= TimeToStayAlive)
        {
            Destroy(this.gameObject);
        }
        timeAlive += Time.deltaTime;
        transform.Rotate(0, 0, -DegreesPerSecond * Time.deltaTime);
        invis++;

        RaycastHit2D hit = Physics2D.Raycast(Box.position, Box.right, 25, Mask);

        Effect.transform.position = hit.point;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "Player" && invis > 150)
        {
            collision.gameObject.GetComponent<Health>().health--;
            invis = 0;
        }
    }
}