using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regeneration : MonoBehaviour
{
    bool HasGiven = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !HasGiven)
        {
            Destroy(this.transform.gameObject);
            HasGiven = true;
            other.gameObject.GetComponent<Health>().health++;
        }
    }
}
