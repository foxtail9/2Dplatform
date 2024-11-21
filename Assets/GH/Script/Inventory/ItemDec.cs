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

            if (itemData as Usable != null)
            {
                UseBtn.SetActive(true);
            }
            else if (itemData as Equipment != null /*&& 현재 장착중인 아이템의 아이템 데이터와 이 아이템 데이터가 같을 경우, 쉽게 말해 선택한 아이템이 장착된 상태일 경우*/)
            {
                UnequipBtn.SetActive(true);
            }
            else if (itemData as Equipment != null /*&& 현재 장착중인 아이템의 아이템 데이터와 이 아이템 데이터가 다를 경우, 쉽게 말해 선택한 아이템이 장착되지 않은 상태일 경우*/)
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
        //아이템 타입을 참고해 현재 장착중인 아이템의 데이터를 선택한걸로 바꾸고 각 스펙 계산
        inventory.UpdateInventoryUI();
        SetItemData(curItemData);
    }

    public void OnUnequipBtn()
    {
        //아이템 타입을 참고해 현재 장착중인 아이템의 데이터를 null로 바꾸고 각 스펙 계산
        inventory.UpdateInventoryUI();
        SetItemData(curItemData);
    }

    public void OnUseBtn()
    {
        //사용 효과 계산(지금은 체력 회복 밖에 없음)
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
