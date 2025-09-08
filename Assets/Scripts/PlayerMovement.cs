using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 25f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input
        moveInput = Input.GetAxisRaw("Horizontal"); // Raw = snappier, good for platformers

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Calculate target velocity
        float targetSpeed = moveInput * maxSpeed;

        // Calculate difference between current and target
        float speedDiff = targetSpeed - rb.linearVelocity.x;

        // Choose acceleration rate (accelerate or decelerate)
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

        // Apply force to reach target speed
        float movement = speedDiff * accelRate;
        rb.AddForce(Vector2.right * movement);

        // Optional: small threshold to zero out tiny velocities (prevents sliding)
        if (Mathf.Abs(rb.linearVelocity.x) < 0.05f && Mathf.Abs(moveInput) < 0.01f)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}