using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
