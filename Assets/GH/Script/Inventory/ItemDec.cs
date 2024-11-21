using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDec : MonoBehaviour
{
    private ContainableItem curItemData;
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemSpec;
    public TextMeshProUGUI itemContent;

    public GameObject EquipBtn;
    public GameObject UnequipBtn;
    public GameObject UseBtn;
    public GameObject DiscardBtn;

    public CharacterInventory inventory;

    public void SetItemData(ContainableItem itemData)
    {
        if (itemData != null)
        {
            curItemData = itemData;
            itemImage.sprite = itemData.IconSprite;
            itemName.text = itemData.ItemName;
            itemContent.text = itemData.ItemExplanation;
            string temp = "";
            if (itemData as Usable != null)
            {
                temp = $"���� ü���� {itemData.Power} ��ŭ ȸ��";
            }
            else if (itemData as Equipment != null)
            {
                if ((itemData as Equipment).type == EquipmentType.Weapon)
                {
                    temp = $"���ݷ� + {itemData.Power}";
                }
                if ((itemData as Equipment).type == EquipmentType.Armor)
                {
                    temp = $"���� + {itemData.Power}";
                }
            }
            itemSpec.text = temp;
            itemImage.gameObject.SetActive(true);
            itemName.gameObject.SetActive(true);
            itemSpec.gameObject.SetActive(true);
            itemContent.gameObject.SetActive(true);

            if (itemData as Usable != null)
            {
                UseBtn.SetActive(true);
            }
            else if (itemData as Equipment != null /*&& ���� �������� �������� ������ �����Ϳ� �� ������ �����Ͱ� ���� ���, ���� ���� ������ �������� ������ ������ ���*/)
            {
                UnequipBtn.SetActive(true);
            }
            else if (itemData as Equipment != null /*&& ���� �������� �������� ������ �����Ϳ� �� ������ �����Ͱ� �ٸ� ���, ���� ���� ������ �������� �������� ���� ������ ���*/)
            {
                EquipBtn.SetActive(true);
            }
            DiscardBtn.SetActive(true);
        }
        else
        {
            curItemData = null;
            itemImage.gameObject.SetActive(false);
            itemName.gameObject.SetActive(false);
            itemSpec.gameObject.SetActive(false);
            itemContent.gameObject.SetActive(false);

            EquipBtn.SetActive(false);
            UnequipBtn.SetActive(false);
            UseBtn.SetActive(false);
            DiscardBtn.SetActive(false);
        }
    }

    public void OnEquipBtn()
    {
        //������ Ÿ���� ������ ���� �������� �������� �����͸� �����Ѱɷ� �ٲٰ� �� ���� ���
        inventory.UpdateInventoryUI();
        SetItemData(curItemData);
    }

    public void OnUnequipBtn()
    {
        //������ Ÿ���� ������ ���� �������� �������� �����͸� null�� �ٲٰ� �� ���� ���
        inventory.UpdateInventoryUI();
        SetItemData(curItemData);
    }

    public void OnUseBtn()
    {
        //��� ȿ�� ���(������ ü�� ȸ�� �ۿ� ����)
        int index = inventory.itemList.IndexOf(curItemData);
        inventory.itemCount[index]--;
        if (inventory.itemCount[index] < 0)
        {
            inventory.itemCount.RemoveAt(index);
            inventory.itemList.RemoveAt(index);
            SetItemData(null);
            inventory.UpdateInventoryUI();
        }
    }

    public void OnDiscardBtn()
    {
        int index = inventory.itemList.IndexOf(curItemData);
        inventory.itemCount.RemoveAt(index);
        inventory.itemList.RemoveAt(index);
        SetItemData(null);
        inventory.UpdateInventoryUI();
    }
}
