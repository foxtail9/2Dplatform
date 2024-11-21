using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UsableType
{
    HpPotion
}
[CreateAssetMenu(fileName = "Usable", menuName = "ContainableItem/Usable", order = 2)]
public class Usable : ContainableItem
{
    public UsableType type;
    
    public override void GetItem(GameObject playerObject)
    {
        //아이템을 인벤토리에 추가.이미 있다면 갯수 증가.
        CharacterInventory characterInventory = playerObject.GetComponent<CharacterInventory>();
        if (characterInventory.itemList.Contains(this)) { int temp = characterInventory.itemList.IndexOf(this); characterInventory.itemCount[temp]++; return; }
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }

    public void UseItem()
    {
        //아이템 사용시 효과 발동
        if (type == UsableType.HpPotion) { UseHpPotion(); }
    }

    void UseHpPotion()
    {
        //power만큼 hp 회복
    }
}
