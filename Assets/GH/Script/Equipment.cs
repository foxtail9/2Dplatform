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
        //�������� �κ��丮�� �߰�, �ش� �������� �ٽ� �������� �ʵ��� ����
        CharacterInventory characterInventory = playerObject.GetComponent<CharacterInventory>();
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }
}