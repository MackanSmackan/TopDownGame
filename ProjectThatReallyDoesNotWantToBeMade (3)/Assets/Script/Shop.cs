using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject DDoL; //D(ont)D(estroy)o(n)L(oad)
    [SerializeField] GameObject CoolSword;
    [SerializeField] GameObject EpicSword;
    [SerializeField] GameObject EpicPotion;
    [SerializeField] GameObject CoolPotion;
    [SerializeField] GameObject TheEncyclopedia;

    [Header("States")]
    [SerializeField] int CS;
    [SerializeField] int ES;
    [SerializeField] int EP;
    [SerializeField] int CP;
    [SerializeField] int TE;

    [Header("Positions")]
    [SerializeField] Transform Pos1;
    [SerializeField] Transform Pos2;
    [SerializeField] Transform Pos3;
    
    
    private void Awake()
    {
        DontDestroyOnLoad(DDoL.gameObject);
    }

    public void Sword()
    {
        DDoL.GetComponent<ItemsBoughtInShop>().SwordMultiplier = 1.25f;
    }

    public void SwitchMainItems()
    {
        CS++;
        ES++;
        EP++;
        CP++;
        TE++;

        if (CS > 5)
        {
            CS = 1;
        }
        if (ES > 5)
        {
            ES = 1;
        }
        if (CP > 5)
        {
            CP = 1;
        }
        if (EP > 5)
        {
            EP = 1;
        }

        if (TE > 5)
        {
            TE = 1;
        }

        if (EP == 1) //what state is Epic potion in
        {
            EpicPotion.active = true;
            EpicPotion.transform.position = Pos1.transform.position;
            EpicPotion.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (EP == 2)
            {
                EpicPotion.transform.position = Pos2.transform.position;
                EpicPotion.transform.localScale = Pos2.transform.localScale;
            }
            else
            {
                if (EP == 3)
                {
                    EpicPotion.transform.position = Pos3.transform.position;
                    EpicPotion.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    EpicPotion.active = false;
                }
            }
        }

        if (ES == 1) //what state is Epic Sword in
        {
            EpicSword.active = true;
            EpicSword.transform.position = Pos1.transform.position;
            EpicSword.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (ES == 2)
            {
                EpicSword.transform.position = Pos2.transform.position;
                EpicSword.transform.localScale = Pos2.transform.localScale;
            }
            else
            {
                if (ES == 3)
                {
                    EpicSword.transform.position = Pos3.transform.position;
                    EpicSword.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    EpicSword.active = false;
                }
            }
        }

        if (CP == 1) //what state is Cool potion in
        {
            CoolPotion.active = true;
            CoolPotion.transform.position = Pos1.transform.position;
            CoolPotion.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (CP == 2)
            {
                CoolPotion.transform.position = Pos2.transform.position;
                CoolPotion.transform.localScale = Pos2.transform.localScale;
            }
            else
            {
                if (CP == 3)
                {
                    CoolPotion.transform.position = Pos3.transform.position;
                    CoolPotion.transform.localScale = Pos3.transform.localScale;
                }
                else
                {
                    CoolPotion.active = false;
                }
            }
        }

        if (CS == 1) //what state is Cool Sword in
        {
            CoolSword.active = true;
            CoolSword.transform.position = Pos1.transform.position;
            CoolSword.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (CS == 2)
            {
                CoolSword.transform.position = Pos2.transform.position;
                CoolSword.transform.localScale = Pos2.transform.localScale;
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
                    CoolSword.active = false;
                }
            }
        }

        if (TE == 1) //what state is The Encyclopedia in
        {
            TheEncyclopedia.active = true;
            TheEncyclopedia.transform.position = Pos1.transform.position;
            TheEncyclopedia.transform.localScale = Pos1.transform.localScale;
        }
        else
        {
            if (TE == 2)
            {
                TheEncyclopedia.transform.position = Pos2.transform.position;
                TheEncyclopedia.transform.localScale = Pos2.transform.localScale;
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
                    TheEncyclopedia.active = false;
                }
            }
        }

    }
}
