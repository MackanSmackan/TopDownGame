using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAlerted : MonoBehaviour
{
    bool Activated;
    float t;
    Vector2 StartPos;
    Vector2 Endpos;
    // Start is called before the first frame update
    void Awake()
    {
        StartPos = this.transform.position;
        Endpos = this.transform.position + new Vector3(0, 1, 0);
        Activated = true;
    }

    private void Update()
    {
        if (Activated)
        {
            this.transform.position = Vector3.Lerp(StartPos, Endpos, t);
            t += Time.deltaTime / 2;

            if(t >= 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
