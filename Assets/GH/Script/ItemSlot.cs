using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public ContainableItem item;
    public Image image;
    public TextMeshProUGUI itemQuantity;
    public TextMeshProUGUI itemEquiped;

    public void Reset()
    {
        item=null;
        image.sprite = null;
        image.enabled = false;
        itemQuantity.text = null;
        itemQuantity.enabled = false;
    }

    public void SetItem(ContainableItem containableItem, int quantity)
    {
        item = containableItem;
        image.sprite=containableItem.IconSprite;
        image.enabled = true;
        itemQuantity.text = quantity.ToString();
        if (containableItem as Usable != null) itemQuantity.enabled = true;
        if(containableItem as Equipment != null /*&& 현재 장착되어 있는 아이템과 같은지 비교*/ )
        {
            itemEquiped.enabled = true;
            itemEquiped.text = "E";
        }
    }

    public void OnClickItemSlot()
    {
        if (item as Usable != null)
        {
            //사용 아이템 관련 메뉴창 열기
        }
        else if (item as Equipment != null)
        {
            //장착 관련 메뉴창 열기
        }
    }
}