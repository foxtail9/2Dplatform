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
        item=null;
        image.GetComponent<Image>().sprite = null;
        image.SetActive(false);
        itemQuantity.GetComponent<TextMeshProUGUI>().text = null;
        itemQuantity.SetActive(false);
        itemEquiped.SetActive(false);
    }

    public void SetItem(ContainableItem containableItem, int quantity)
    {
        item = containableItem;
        image.GetComponent<Image>().sprite=containableItem.IconSprite;
        image.SetActive(true);
        itemQuantity.GetComponent<TextMeshProUGUI>().text = quantity.ToString();
        if (containableItem as Usable != null) itemQuantity.SetActive(true);
        if(containableItem as Equipment != null /*&& 현재 장착되어 있는 아이템과 같은지 비교*/ )
        {
            itemEquiped.SetActive(true);
            itemEquiped.GetComponent<TextMeshProUGUI>().text = "E";
        }
    }

    public void OnClickItemSlot()
    {
        transform.root.GetChild(1).GetComponent<CharacterInventory>().SetItemDec(item);
    }
}