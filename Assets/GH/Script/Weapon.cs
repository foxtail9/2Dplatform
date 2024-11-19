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
        //�������� �κ��丮�� �߰�, �ش� �������� �ٽ� �������� �ʵ��� ����
        CharacterInventory characterInventory = playerObject.GetComponent<CharacterInventory>();
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }
}