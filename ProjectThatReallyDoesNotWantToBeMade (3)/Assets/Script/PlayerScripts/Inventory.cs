using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject DDoLPrefab;
    GameObject DDoL;
    public int Shards;
    [SerializeField] Text text;
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("DontDestroyOnLoad") != null)
        {
            DDoL = GameObject.FindGameObjectWithTag("DontDestroyOnLoad");
            Shards = DDoL.GetComponent<DontDestroyShardCounter>().Shards;
            text.text = "Shards: " + Shards;
        }
        else
        {
            DDoL = Instantiate(DDoLPrefab);
            DontDestroyOnLoad(DDoL);
            Shards = DDoL.GetComponent<DontDestroyShardCounter>().Shards;
            text.text = "Shards: " + Shards;
        }
        
    }
    // Start is called before the first frame update
    public void GetShard()
    {
        Shards++;
        text.text = "Shards: " + Shards;
        DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
    }
}
