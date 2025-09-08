using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * acceleration, 0));
        if (Mathf.Abs(rb.linearVelocityX) > maxSpeed)
        {
            float setVelocity = Mathf.Clamp(rb.linearVelocityX, -maxSpeed, maxSpeed);
            rb.linearVelocity = new Vector2(setVelocity, rb.linearVelocityY);
        }
        if (Input.GetKeyDown(KeyCode.W)) rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //TODO: Add Raycast to check if grounded
    }
}
