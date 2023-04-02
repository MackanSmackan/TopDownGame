using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int Shards;
    [SerializeField] Text text;
    // Start is called before the first frame update
    public void GetShard()
    {
        Shards++;
        text.text = "Shards: " + Shards;
    }
}
