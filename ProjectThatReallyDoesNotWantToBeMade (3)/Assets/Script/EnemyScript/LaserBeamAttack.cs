using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamAttack : MonoBehaviour
{
    [SerializeField] Transform Box;
    [SerializeField] float DegreesPerSecond;
    [SerializeField] Transform Effect;
    [SerializeField] LayerMask Mask;
    public Transform MaxPos;
    public Transform MinPos;
    public bool HasTransforms;
    bool HasPositions;
    Vector2 position;
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
        if (HasTransforms && !HasPositions)
        {
            HasPositions = true;
            position = new Vector2(Random.Range(MinPos.position.x, MaxPos.position.x), Random.Range(MinPos.position.y, MaxPos.position.y));
        }
        if (timeAlive >= TimeToStayAlive)
        {
            Destroy(this.gameObject);
        }
        timeAlive += Time.deltaTime;
        transform.Rotate(0, 0, -DegreesPerSecond * Time.deltaTime);
        invis++;

        if (HasPositions)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, position, TimeToStayAlive);
        }

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