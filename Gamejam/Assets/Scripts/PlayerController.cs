using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Animator animator;
    public int health = 5;
    public EnemySpawner enemySpawner;
    private Rigidbody2D rb2d;
    private Vector2 movementDirection;

    private float minX, maxX, minY, maxY;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Calculate the boundaries of the screen
        Vector3 lowerLeftCorner = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 upperRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Update the boundaries considering the size of the player object
        minX = lowerLeftCorner.x + 0.5f;
        maxX = upperRightCorner.x - 0.5f;
        minY = lowerLeftCorner.y + 0.5f;
        maxY = upperRightCorner.y - 0.5f;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movementDirection = new Vector2(moveHorizontal, moveVertical);

        if (movementDirection != Vector2.zero)
        {
            animator.SetBool("MovingFront", true);
        }
        else
        {
            animator.SetBool("MovingFront", false);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb2d.velocity = movementDirection * movementSpeed;

        // Clamp the position to the screen boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemySpawner.MultiplySpawnRate();
        }
    }

}