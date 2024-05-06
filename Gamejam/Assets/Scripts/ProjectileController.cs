using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        // Calculate the direction towards the mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // Move the object in the calculated direction
        transform.Translate(direction * speed * Time.deltaTime);
    }
}