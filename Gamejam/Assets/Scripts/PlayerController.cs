using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 4f;
    private Rigidbody2D rb2d;
    private Vector2 movementDirection;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movementDirection = new Vector2(moveHorizontal, moveVertical);
    }

    void FixedUpdate()
    {
        rb2d.velocity = movementDirection * movementSpeed;
    }
}