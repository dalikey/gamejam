using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float lifetime = 2f;

    private Vector2 direction;

    void Start()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
