using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 50; 
    public int currentHealth;
    public Animator animator;
    public GameObject dropItem;
    public List<ContainableItem> dropItems;
    public GameObject OnfieldItem;
    public List<OnFieldItem> onFieldItems;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameObject temp = Instantiate(dropItem, transform.position, Quaternion.identity);
            int i = Random.Range(0, dropItems.Count);
            temp.GetComponent<DropItem>().itemData = dropItems[i];
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, 0.3f); 
    }
}

