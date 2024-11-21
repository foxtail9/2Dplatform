using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 50; 
    public int currentHealth;  

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, 0.3f); 
    }
}

