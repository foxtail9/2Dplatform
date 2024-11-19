using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Helmet,
    Armor
}
[CreateAssetMenu(fileName = "Equipment", menuName = "ContainableItem/Equipment", order = 0)]
public class Equipment : ContainableItem
{
    public EquipmentType type;
    public int power;
    public int price;
    public override void GetItem(GameObject playerObject)
    {
        //아이템을 인벤토리에 추가, 해당 아이템이 다시 등장하지 않도록 설정
        CharacterInventory characterInventory = playerObject.GetComponent<CharacterInventory>();
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }
}
