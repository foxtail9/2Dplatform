using TMPro;
using UnityEngine;

public class DropItemInfo : MonoBehaviour
{
    private ContainableItem itemData;
    [SerializeField]
    private TextMeshPro itemName;
    [SerializeField]
    private TextMeshPro itemDescription;
    private Collider2D collision;
    
    public void SetInfo(ContainableItem item, Collider2D playerCollider)
    {
        itemData = item;
        itemName.text = itemData.ItemName;
        itemDescription.text = itemData.ItemExplanation;
        collision = playerCollider;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z)) //z ¿‘∑¬¿∏∑Œ æ∆¿Ã≈€ »πµÊ
        {
            itemData.GetItem(collision.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}