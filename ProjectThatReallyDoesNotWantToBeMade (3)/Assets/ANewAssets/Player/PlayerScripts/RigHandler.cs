using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigHandler : MonoBehaviour
{
    [Header("Rigs")]
    [SerializeField] GameObject NorthRig;
    [SerializeField] GameObject SouthRig;
    [SerializeField] GameObject WestRig;
    [SerializeField] GameObject EastRig;

    Animator NorthAnimator;
    Animator SouthAnimator;
    Animator EastAnimator;
    Animator WestAnimator;

    private void Start()
    {
        NorthAnimator = NorthRig.GetComponent<Animator>();
        SouthAnimator = SouthRig.GetComponent<Animator>();
        EastAnimator = WestRig.GetComponent<Animator>();
        WestAnimator = EastRig.GetComponent<Animator>();
    }

    public void SetNorth()
    {
        NorthRig.SetActive(true);
        SouthRig.SetActive(false);
        WestRig.SetActive(false);
        EastRig.SetActive(false);
    }

    public void SetSouth()
    {
        SouthRig.SetActive(true);
        NorthRig.SetActive(false);
        WestRig.SetActive(false);
        EastRig.SetActive(false);
    }

    public void SetWest()
    {
        WestRig.SetActive(true);
        NorthRig.SetActive(false);
        SouthRig.SetActive(false);
        EastRig.SetActive(false);
    }

    public void SetEast()
    {
        EastRig.SetActive(true);
        NorthRig.SetActive(false);
        SouthRig.SetActive(false);
        WestRig.SetActive(false);
    }

    public void SetRigAnimatorInt(string ParameterName, int Value)
    {
        if(NorthAnimator.gameObject.activeSelf)
        {
            NorthAnimator.SetInteger(ParameterName, Value);
        }
        if (SouthAnimator.gameObject.activeSelf)
        {
            SouthAnimator.SetInteger(ParameterName, Value);
        }
        if (EastAnimator.gameObject.activeSelf)
        {
            EastAnimator.SetInteger(ParameterName, Value);
        }
        if (WestAnimator.gameObject.activeSelf)
        {
            WestAnimator.SetInteger(ParameterName, Value);
        }
    }

    public void SetRigAnimatorFloat(string ParameterName, float Value)
    {
        if (NorthAnimator.gameObject.activeSelf)
        {
            NorthAnimator.SetFloat(ParameterName, Value);
        }
        if (SouthAnimator.gameObject.activeSelf)
        {
            SouthAnimator.SetFloat(ParameterName, Value);
        }
        if (EastAnimator.gameObject.activeSelf)
        {
            EastAnimator.SetFloat(ParameterName, Value);
        }
        if (WestAnimator.gameObject.activeSelf)
        {
            WestAnimator.SetFloat(ParameterName, Value);
        }
    }

    public void SetRigAnimatorBool(string ParameterName, bool Value)
    {
        if (NorthAnimator.gameObject.activeSelf)
        {
            NorthAnimator.SetBool(ParameterName, Value);
        }
        if (SouthAnimator.gameObject.activeSelf)
        {
            SouthAnimator.SetBool(ParameterName, Value);
        }
        if (EastAnimator.gameObject.activeSelf)
        {
            EastAnimator.SetBool(ParameterName, Value);
        }
        if (WestAnimator.gameObject.activeSelf)
        {
            WestAnimator.SetBool(ParameterName, Value);
        }
    }
}
