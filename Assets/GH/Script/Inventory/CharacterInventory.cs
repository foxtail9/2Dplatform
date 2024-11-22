using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterInventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots;
    public List<ContainableItem> itemList;
    public List<int> itemCount;
    public ItemDec itemDec;
    public Player player;
    public int money=0;
    public TextMeshProUGUI moneyText;

    private void OnEnable()
    {
        UpdateInventoryUI();
        itemDec.SetItemData(null);
    }
    public void UpdateInventoryUI()
    {
        for (int i = 0; i < itemSlots.Count; i++) 
        {
            if(itemList.Count > i)
            {
                itemSlots[i].SetItem(itemList[i], itemCount[i]);
            }
            else
            {
                itemSlots[i].Reset();
            }
        }
    }

    public void GetMoney(int coin)
    {
        money += coin;
        moneyText.text = money.ToString() + " Gold";
    }

    public void OnClickExit()
    {
        gameObject.SetActive(false);
    }

    public void SetItemDec(ContainableItem itemData)
    {
        itemDec.SetItemData(itemData);
    }
}