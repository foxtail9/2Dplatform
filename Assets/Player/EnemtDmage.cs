using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 50; 
    public int currentHealth;
    public Animator animator;

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
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, 0.3f); 
    }
}

