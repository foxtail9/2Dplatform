using UnityEngine;

public class TestEnemy : MonoBehaviour
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
        Destroy(gameObject, 0.5f); 
    }
}

