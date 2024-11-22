using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public ContainableItem item;
    public GameObject image;
    public GameObject itemQuantity;
    public GameObject itemEquiped;


    public void Reset()
    {
        item = null;
        image.GetComponent<Image>().sprite = null;
        image.SetActive(false);
        itemQuantity.GetComponent<TextMeshProUGUI>().text = null;
        itemQuantity.SetActive(false);
        itemEquiped.SetActive(false);
    }

    public void SetItem(ContainableItem containableItem, int quantity)
    {
        item = containableItem;
        image.GetComponent<Image>().sprite = containableItem.IconSprite;
        image.SetActive(true);
        itemQuantity.GetComponent<TextMeshProUGUI>().text = quantity.ToString();
        itemQuantity.SetActive(false);
        if (containableItem as Usable != null) itemQuantity.SetActive(true);
        if (containableItem as Equipment != null)
        {
            if (transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedWeapon != null)
            {
                if ((containableItem as Equipment).type == EquipmentType.Weapon && transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedWeapon == containableItem as Equipment)
                {
                    itemEquiped.SetActive(true);
                    itemEquiped.GetComponent<TextMeshProUGUI>().text = "E";
                }
            }
            else if (transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedArmor != null)
            {
                if ((containableItem as Equipment).type == EquipmentType.Armor && transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedArmor != null && transform.root.GetChild(1).GetComponent<CharacterInventory>().player.equippedArmor == containableItem as Equipment)
                {
                    itemEquiped.SetActive(true);
                    itemEquiped.GetComponent<TextMeshProUGUI>().text = "E";
                }
            }
            else
            {
                itemEquiped.SetActive(false);
            }
        }
    }

    public void OnClickItemSlot()
    {
        transform.root.GetChild(1).GetComponent<CharacterInventory>().SetItemDec(item);
    }
}