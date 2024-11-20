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

    private void OnEnable()
    {
        UpdateInventoryUI();
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

    public void OnClickExit()
    {
        gameObject.SetActive(false);
    }
}