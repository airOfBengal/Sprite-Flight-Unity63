using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float thurstForce = 1f;
    Rigidbody2D rb;
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    public UIDocument uiDocument;
    private Label scoreLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreLabel = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction; // Rotate the player to face the mouse position

            rb.AddForce(direction * thurstForce);
        }
    }

    private void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier); // Update score based on elapsed time
        scoreLabel.text = $"Score: {score}"; // Update the score label in the UI
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // Destroy the player on collision with any obstacle
    }
}
