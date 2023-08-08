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

    public void SetRigAnimatorFloat(string ParameterName, float Value)
    {
        NorthAnimator.SetFloat(ParameterName, Value);
        SouthAnimator.SetFloat(ParameterName, Value);
        EastAnimator.SetFloat(ParameterName, Value);
        WestAnimator.SetFloat(ParameterName, Value);
    }

    public void SetRigAnimatorTrigger(string ParameterName)
    {
        NorthAnimator.SetTrigger(ParameterName);
        SouthAnimator.SetTrigger(ParameterName);
        EastAnimator.SetTrigger(ParameterName);
        WestAnimator.SetTrigger(ParameterName);
    }
}
