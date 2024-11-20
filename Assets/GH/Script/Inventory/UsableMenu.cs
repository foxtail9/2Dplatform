using UnityEngine;
using UnityEngine.UI;

public class UsableMenu : MonoBehaviour
{
    public Usable item;
    public CharacterInventory inventory;

    public void UseItem()
    {
        //������ ���� ȿ�� �ߵ�
        if (item.type == UsableType.HpPotion) { 
            UseHpPotion(); 
        }
        int temp = inventory.itemList.IndexOf(item);
        inventory.itemCount[temp]--;
        if (inventory.itemCount[temp] <= 0)
        {
            inventory.itemList.RemoveAt(temp);
            inventory.itemCount.RemoveAt(temp);
        }
        inventory.UpdateInventoryUI();
    }

    public void DiscardItem()
    {
        int temp = inventory.itemList.IndexOf(item);
        inventory.itemList.RemoveAt(temp);
        inventory.itemCount.RemoveAt(temp);
        inventory.UpdateInventoryUI();
    }

    void UseHpPotion()
    {
        //power��ŭ hp ȸ��
    }
}