using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100; // 최대 체력
    public int currentHealth;  // 현재 체력
    public int attackDamage = 10; // 공격력
    public float knockbackForce = 5f; 

    public Animator attackAnimator;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f; // 공격 범위
    public LayerMask enemyLayers;

    public int defense; // 방어력

    private bool canAttack = true; 
    private Rigidbody2D rb;

    public Equipment equippedWeapon = null;
    public Equipment equippedArmor = null;

    public CharacterInventory inventory;

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

    // 아이템 장착
    public void EquipItem(Equipment item)
    {
        if (item == null) return;

        if (item.type == EquipmentType.Weapon)
        {
            if (equippedWeapon != null)
            {
                UnequipItem(equippedWeapon); 
            }

            equippedWeapon = item;
            attackDamage += item.Power; 
        }
        else if (item.type == EquipmentType.Armor)
        {
            if (equippedArmor != null)
            {
                UnequipItem(equippedArmor); 
            }

            equippedArmor = item;
            defense += item.Power; 
        }

        Debug.Log($"{item.ItemName} 장착 완료");

        //Player player = FindObjectOfType<Player>();
        //player.EquipItem((Equipment)curItemData);
        //Dec에 추가해주기
    }

    // 아이템 해제
    public void UnequipItem(Equipment item)
    {
        if (item == null) return;

        if (item.type == EquipmentType.Weapon && item == equippedWeapon)
        {
            attackDamage -= item.Power; 
            equippedWeapon = null;
        }
        else if (item.type == EquipmentType.Armor && item == equippedArmor)
        {
            defense -= item.Power; 
            equippedArmor = null;
        }

        Debug.Log($"{item.ItemName} 해제 완료");

        //Player player = FindObjectOfType<Player>();
        //player.UnequipItem((Equipment)curItemData);
        //Dec에 추가해주기
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= Mathf.Max(0, damage - defense); 

        animator.SetTrigger("Hurt");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

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
            enemy.GetComponent<EnemyDamage>()?.TakeDamage(attackDamage);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
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

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth >= maxHealth) { currentHealth = maxHealth; }
    }
}
