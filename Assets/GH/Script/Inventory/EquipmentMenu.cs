using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenu : MonoBehaviour
{
    public Equipment item;
    public CharacterInventory inventory;

    public void EquipItem()
    {
        //EquipmentType ���� ���� ���� ���� ã�Ƽ� ������ �׳� ���� �� ���� ���� ������ ���� �ִ��� ��� �����ϰ� ���� ���
    }

    public void UnequipItem()
    {
        //EquipmentType Ȯ�� �� ���� ����
    }

    public void DiscardItem()
    {
        int temp = inventory.itemList.IndexOf(item);
        inventory.itemList.RemoveAt(temp);
        inventory.itemCount.RemoveAt(temp);
        inventory.UpdateInventoryUI();
    }
}