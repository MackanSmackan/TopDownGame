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
    public int HealthPotions;
    public int SpeedPotions;
    public bool SpeedShoes;
    public bool TE;
    [SerializeField] Text text;
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("DontDestroyOnLoad") != null)
        {
            DDoL = GameObject.FindGameObjectWithTag("DontDestroyOnLoad");
            Shards = DDoL.GetComponent<DontDestroyShardCounter>().Shards;
            HealthPotions = DDoL.GetComponent<DontDestroyShardCounter>().HealthPots;
            SpeedPotions = DDoL.GetComponent<DontDestroyShardCounter>().SpeedPots;
            SpeedShoes = DDoL.GetComponent<DontDestroyShardCounter>().SpeedShoes;
            TE = DDoL.GetComponent<DontDestroyShardCounter>().TE;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && HealthPotions >= 0)
        {
            this.GetComponent<Health>().health++;
            HealthPotions--;
            DDoL.GetComponent<DontDestroyShardCounter>().HealthPots--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && SpeedPotions >= 0)
        {
            StartCoroutine(Speed());
        }
    }

    IEnumerator Speed()
    {
        this.GetComponent<Movement>().moveSpeed++;       
        DDoL.GetComponent<DontDestroyShardCounter>().SpeedPots--;
        SpeedPotions--;
        yield return new WaitForSeconds(300);
        this.GetComponent<Movement>().moveSpeed--;

    }
}
