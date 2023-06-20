using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    int Shards;
    public string LoadLevel;
    [Header("Objects")]
    GameObject DDoL; //D(ont)D(estroy)o(n)L(oad)
    [SerializeField] GameObject CoolSword;
    [SerializeField] GameObject SpeedyShoes;
    [SerializeField] GameObject SpeedPotion;
    [SerializeField] GameObject HealthPotion;
    [SerializeField] GameObject TheEncyclopedia;
    [SerializeField] Text CostText;

    [Header("States")]
    [SerializeField] int CS;
    [SerializeField] int ES;
    [SerializeField] int SP;
    [SerializeField] int HP;
    [SerializeField] int TE;

    [Header("Positions")]
    [SerializeField] Transform Pos1;
    [SerializeField] Transform Pos2;
    [SerializeField] Transform Pos3;
    
    
    private void Awake()
    {
        DDoL = GameObject.FindGameObjectWithTag("DontDestroyOnLoad");
        Shards = DDoL.GetComponent<DontDestroyShardCounter>().Shards;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(LoadLevel);
        }
    }

    public void SwitchMainItems()
    {
        CS++;
        ES++;
        SP++;
        HP++;
        TE++;

        if (CS > 5)
        {
            CS = 1;
        }
        if (ES > 5)
        {
            ES = 1;
        }
        if (HP > 5)
        {
            HP = 1;
        }
        if (SP > 5)
        {
            SP = 1;
        }

        if (TE > 5)
        {
            TE = 1;
        }

        if (SP == 1) //what state is SPic potion in
        {
            SpeedPotion.SetActive(true);
            SpeedPotion.transform.position = Pos1.transform.position;
            SpeedPotion.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (SP == 2)
            {
                SpeedPotion.transform.position = Pos2.transform.position;
                SpeedPotion.transform.localScale = Pos2.transform.localScale;
                CostText.text = "X 10";
            }
            else
            {
                if (SP == 3)
                {
                    SpeedPotion.transform.position = Pos3.transform.position;
                    SpeedPotion.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    SpeedPotion.SetActive(false);
                }
            }
        }

        if (ES == 1) //what state is SPic Sword in
        {
            SpeedyShoes.SetActive(true);
            SpeedyShoes.transform.position = Pos1.transform.position;
            SpeedyShoes.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (ES == 2)
            {
                SpeedyShoes.transform.position = Pos2.transform.position;
                SpeedyShoes.transform.localScale = Pos2.transform.localScale;
                CostText.text = "X 150";
            }
            else
            {
                if (ES == 3)
                {
                    SpeedyShoes.transform.position = Pos3.transform.position;
                    SpeedyShoes.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    SpeedyShoes.SetActive(false);
                }
            }
        }

        if (HP == 1) //what state is Cool potion in
        {
            HealthPotion.SetActive(true);
            HealthPotion.transform.position = Pos1.transform.position;
            HealthPotion.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (HP == 2)
            {
                HealthPotion.transform.position = Pos2.transform.position;
                HealthPotion.transform.localScale = Pos2.transform.localScale;
                CostText.text = "X 10";
            }
            else
            {
                if (HP == 3)
                {
                    HealthPotion.transform.position = Pos3.transform.position;
                    HealthPotion.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    HealthPotion.SetActive(false);
                }
            }
        }

        if (CS == 1) //what state is Cool Sword in
        {
            CoolSword.SetActive(true);
            CoolSword.transform.position = Pos1.transform.position;
            CoolSword.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (CS == 2)
            {
                CoolSword.transform.position = Pos2.transform.position;
                CoolSword.transform.localScale = Pos2.transform.localScale;
                CostText.text = "X 50";
            }
            else
            {
                if (CS == 3)
                {
                    CoolSword.transform.position = Pos3.transform.position;
                    CoolSword.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    CoolSword.SetActive(false);
                }
            }
        }

        if (TE == 1) //what state is The Encyclopedia in
        {
            TheEncyclopedia.SetActive(true);
            TheEncyclopedia.transform.position = Pos1.transform.position;
            TheEncyclopedia.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (TE == 2)
            {
                TheEncyclopedia.transform.position = Pos2.transform.position;
                TheEncyclopedia.transform.localScale = Pos2.transform.localScale;
                CostText.text = "X 100";
            }
            else
            {
                if (TE == 3)
                {
                    TheEncyclopedia.transform.position = Pos3.transform.position;
                    TheEncyclopedia.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    TheEncyclopedia.SetActive(false);
                }
            }
        }

    }

    public void BuySpeedShoes()
    {
        if (150 <= Shards)
        {
            print(Shards);
            Shards = Shards - 150;
            DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
            DDoL.GetComponent<DontDestroyShardCounter>().SpeedShoes = true;
        }
    }
    public void BuyHealthPotion()
    {
        if (10 <= Shards)
        {
            Shards = Shards - 10;
            DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
            DDoL.GetComponent<DontDestroyShardCounter>().HealthPots++;
        }
    }

    public void BuySpeedPotion()
    {
        if (10 <= Shards)
        {
            Shards = Shards - 10;
            DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
            DDoL.GetComponent<DontDestroyShardCounter>().SpeedPots++;
        }
    }

    public void BuyAttackPotion()
    {
        if (10 <= Shards)
        {
            Shards = Shards - 10;
            DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
        }
    }

    public void BuyTheEncylopedia()
    {
        if (100 <= Shards)
        {
            Shards = Shards - 100;
            DDoL.GetComponent<DontDestroyShardCounter>().Shards = Shards;
        }
    }
}
