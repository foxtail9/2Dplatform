using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor
}
[CreateAssetMenu(fileName = "Equipment", menuName = "ContainableItem/Equipment", order = 0)]
public class Equipment : ContainableItem
{
    public EquipmentType type;
    
    public int price;
    public override void GetItem(GameObject playerObject)
    {
        CharacterInventory characterInventory = playerObject.GetComponent<Player>().inventory;
        if (characterInventory.itemList.Contains(this)) 
        {
            return;
        }
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }
}
