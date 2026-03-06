using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float thurstForce = 1f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction; // Rotate the player to face the mouse position

            rb.AddForce(direction * thurstForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // Destroy the player on collision with any obstacle
    }
}
