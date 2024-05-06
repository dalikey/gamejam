using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    private Vector2 mousePosition;

    private void Start()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        // Move the object in the calculated direction
        transform.Translate(mousePosition * speed * Time.deltaTime);
    }
}
