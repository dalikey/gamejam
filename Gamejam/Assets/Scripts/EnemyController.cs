using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int damage = 1;
    private Rigidbody2D rb2d;
    private GameObject player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Randomize initial movement direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        SetInitialMovementDirection(randomDirection);
    }

    void FixedUpdate()
    {
        // Move the enemy towards the player if the player is not null
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb2d.velocity = direction * movementSpeed;
        }

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetInitialMovementDirection(Vector2 direction)
    {
        rb2d.velocity = direction * movementSpeed;
    }

    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log(other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
    }
}
