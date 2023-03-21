using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Shards;
    // Start is called before the first frame update
    public void GetShard()
    {
        Shards++;
    }
}
