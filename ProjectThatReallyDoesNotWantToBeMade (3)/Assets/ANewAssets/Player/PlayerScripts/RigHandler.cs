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
        NorthAnimator.SetInteger(ParameterName, Value);
        SouthAnimator.SetInteger(ParameterName, Value);
        EastAnimator.SetInteger(ParameterName, Value);
        WestAnimator.SetInteger(ParameterName, Value);
    }

    public void SetRigAnimatorBool(string ParameterName, bool Value)
    {
        NorthAnimator.SetBool(ParameterName, Value);
        SouthAnimator.SetBool(ParameterName, Value);
        EastAnimator.SetBool(ParameterName, Value);
        WestAnimator.SetBool(ParameterName, Value);
    }
}
