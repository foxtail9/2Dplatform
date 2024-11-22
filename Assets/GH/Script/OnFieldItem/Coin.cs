using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : OnFieldItem
{
    [SerializeField]
    private int coinAmount;
    public override void GetItem(GameObject PlayerObject)
    {
        //ĳ���� ���� �� �� ����
        CharacterInventory characterInventory = PlayerObject.GetComponent<Player>().inventory;
        characterInventory.GetMoney(coinAmount);
    }
}