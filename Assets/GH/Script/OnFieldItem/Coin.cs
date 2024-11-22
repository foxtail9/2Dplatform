using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : OnFieldItem
{
    [SerializeField]
    private int coinAmount;
    public override void GetItem(GameObject PlayerObject)
    {
        //캐릭터 정보 중 돈 증가
        CharacterInventory characterInventory = PlayerObject.GetComponent<Player>().inventory;
        characterInventory.GetMoney(coinAmount);
    }
}