using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;   
    public int currentHealth;    
    public int attackDamage = 10; 
    public float knockbackForce = 5f; 

    public Animator attackAnimator;
    public Animator animator;    
    public Transform attackPoint;
    public float attackRange = 0.5f; 
    public LayerMask enemyLayers;   

    private bool canAttack = true; 
    private Rigidbody2D rb; 

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canAttack)
        {
            Attack();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void Knockback(int damage, Vector2 knockbackDirection)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        animator.SetBool("IsDead", true);
    }

    private void Attack()
    {
        attackAnimator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TestEnemy>()?.TakeDamage(attackDamage);
        }

        canAttack = false;
        Invoke(nameof(ResetAttack), 0.4f); 
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            Knockback(10, knockbackDirection);
        }
    }
}
