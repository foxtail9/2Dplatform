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
        //�������� �κ��丮�� �߰�.�̹� �ִٸ� ���� ����.
        CharacterInventory characterInventory = playerObject.GetComponent<CharacterInventory>();
        if (characterInventory.itemList.Contains(this)) { int temp = characterInventory.itemList.IndexOf(this); characterInventory.itemCount[temp]++; return; }
        characterInventory.itemList.Add(this);
        characterInventory.itemCount.Add(1);
    }

    public void UseItem()
    {
        //������ ���� ȿ�� �ߵ�
        if (type == UsableType.HpPotion) { UseHpPotion(); }
    }

    void UseHpPotion()
    {
        //power��ŭ hp ȸ��
    }
}
