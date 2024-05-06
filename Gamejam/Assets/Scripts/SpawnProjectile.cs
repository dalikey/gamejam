using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject Bullet;

    public void Spawn(Vector2 playerPosition)
    {
        Instantiate(Bullet, playerPosition, Quaternion.identity);
    }
}
