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
                temp = $"사용시 체력을 {itemData.Power} 만큼 회복";
            }
            else if (itemData as Equipment != null)
            {
                if ((itemData as Equipment).type == EquipmentType.Weapon)
                {
                    temp = $"공격력 + {itemData.Power}";
                }
                if ((itemData as Equipment).type == EquipmentType.Armor)
                {
                    temp = $"방어력 + {itemData.Power}";
                }
            }
            itemSpec.text = temp;
            itemImage.gameObject.SetActive(true);
            itemName.gameObject.SetActive(true);
            itemSpec.gameObject.SetActive(true);
            itemContent.gameObject.SetActive(true);

            EquipBtn.SetActive(false);
            UnequipBtn.SetActive(false);
            UseBtn.SetActive(false);
            DiscardBtn.SetActive(false);

            if (itemData as Usable != null)
            {
                UseBtn.SetActive(true);
            }
            else if (itemData as Equipment != null && (transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedArmor == itemData as Equipment|| transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedWeapon == itemData as Equipment))
            {
                UnequipBtn.SetActive(true);
            }
            else if (itemData as Equipment != null)
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
        transform.root.GetChild(1).GetComponent<CharacterInventory>().player.EquipItem(curItemData as Equipment);
        inventory.UpdateInventoryUI();
        SetItemData(curItemData);
    }

    public void OnUnequipBtn()
    {
        transform.root.GetChild(1).GetComponent<CharacterInventory>().player.UnequipItem(curItemData as Equipment);
        inventory.UpdateInventoryUI();
        SetItemData(curItemData);
    }

    public void OnUseBtn()
    {
        transform.root.GetChild(1).GetComponent<CharacterInventory>().player.Heal(curItemData.Power);
        int index = inventory.itemList.IndexOf(curItemData);
        inventory.itemCount[index]--;
        if (inventory.itemCount[index] <= 0)
        {
            inventory.itemCount.RemoveAt(index);
            inventory.itemList.RemoveAt(index);
            SetItemData(null);   
        }
        inventory.UpdateInventoryUI();
    }

    public void OnDiscardBtn()
    {
        transform.root.GetChild(1).GetComponent<CharacterInventory>().player.UnequipItem(curItemData as Equipment);
        int index = inventory.itemList.IndexOf(curItemData);
        inventory.itemCount.RemoveAt(index);
        inventory.itemList.RemoveAt(index);
        SetItemData(null);
        inventory.UpdateInventoryUI();
    }
}
