using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    private Rigidbody2D rb;
    public float minSpeed = 50f;
    public float maxSpeed = 100f;
    public float maxSpinSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize; // Adjust speed based on size (smaller obstacles move faster)
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);

        float randomSpin = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomSpin);
    }
}
