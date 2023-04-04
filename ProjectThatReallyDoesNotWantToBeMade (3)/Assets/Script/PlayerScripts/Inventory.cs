using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    GameObject DDoL;
    public int Shards;
    [SerializeField] Text text;
    private void Awake()
    {
        DDoL = GameObject.FindGameObjectWithTag("DontDestroyOnLoad");
        DontDestroyOnLoad(DDoL);
        Shards = DDoL.GetComponent<DontDestroyShardCounter>().Shards;
    }
    // Start is called before the first frame update
    public void GetShard()
    {
        Shards++;
        text.text = "Shards: " + Shards;
        DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
    }
}
