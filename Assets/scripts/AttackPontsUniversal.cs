using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPontsUniversal : MonoBehaviour
{
    public GameObject handAttackPoint, legAttackPoint;
    private void HandAttackOn()
    {
        handAttackPoint.SetActive(true);
    }
    private void HandAttackOff()
    {
        handAttackPoint.SetActive(false);
    }

    private void LegAttackOn()
    {
        legAttackPoint.SetActive(true);
    }
    private void LegAttackOff()
    {
        legAttackPoint.SetActive(false);
    }
}
