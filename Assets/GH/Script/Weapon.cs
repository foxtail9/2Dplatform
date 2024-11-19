using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ContainableItem/Weapon", order = 1)]
public class Weapon : Equipment 
{
    public EquipmentType type = EquipmentType.Weapon;
    public float range;
    public float delay;
    public GameObject weaponPrefab;
    public override void GetItem(GameObject playerObject)
    {
        //아이템을 인벤토리에 추가, 해당 아이템이 다시 등장하지 않도록 설정
        CharacterInventory characterInventory = playerObject.GetComponent<CharacterInventory>();
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }
}