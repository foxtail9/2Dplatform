using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealFragment : OnFieldItem
{
    [SerializeField]
    private int HealAmount;
    public override void GetItem(GameObject PlayerObject)
    {
        // PlayerObject.GetComponent<PlayerState>().HP+=HealAmount;
    }
}