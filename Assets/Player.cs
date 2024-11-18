using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth;  
    public int attackDamage = 10; 

    public Animator animator;    
    public Transform attackPoint; 
    public float attackRange = 0.5f; 
    public LayerMask enemyLayers;  

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            TakeDamage(50);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Debug.Log("Á×À½");
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TestEnemy>()?.TakeDamage(attackDamage);
        }
        Debug.Log("°ø°Ý");
    }

}
