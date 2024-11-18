using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    private float horizontal;
    private float speed = 5f;
    private float jumpForce = 5f;
    private bool isFacingRight = true;
    private bool isGrounded = true;

    public static Player player;

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;

            animator.SetBool("IsJumping", true);
        }
    }

    public void Attack()
    {
        player.Attack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            animator.SetBool("IsJumping", false);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        float rotationY = isFacingRight ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
