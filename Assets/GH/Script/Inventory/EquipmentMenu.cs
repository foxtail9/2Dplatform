using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenu : MonoBehaviour
{
    public Equipment item;
    public CharacterInventory inventory;

    public void EquipItem()
    {
        //EquipmentType 따라 같은 부위 장착 찾아서 없으면 그냥 장착 및 스탯 증가 있으면 원래 있던거 대신 장착하고 스탯 계산
    }

    public void UnequipItem()
    {
        //EquipmentType 확인 후 부위 해제
    }

    public void DiscardItem()
    {
        int temp = inventory.itemList.IndexOf(item);
        inventory.itemList.RemoveAt(temp);
        inventory.itemCount.RemoveAt(temp);
        inventory.UpdateInventoryUI();
    }
}