using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ContainableItem itemData;
    public Sprite itemImage;
    public DropItemInfo itemInfo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemInfo.gameObject.SetActive(true);
            itemInfo.SetInfo(itemData, collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itemInfo.gameObject.SetActive(false);
    }
}