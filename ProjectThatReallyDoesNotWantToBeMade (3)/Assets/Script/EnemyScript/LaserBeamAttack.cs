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

    private void Awake()
    {
        invis = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -DegreesPerSecond * Time.deltaTime);
        invis++;
        RaycastHit2D hit = Physics2D.Raycast(Box.position, Box.forward);

        print(hit.point);

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Box.position, Box.forward);
    }
}