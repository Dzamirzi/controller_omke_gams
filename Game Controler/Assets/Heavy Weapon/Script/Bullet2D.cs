using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    public BulletData bulletData;
    [Tooltip("Which layer the bullet should damage (e.g., Enemy)")]
    public LayerMask enemyLayer;

    private void Start()
    {
        Destroy(gameObject, bulletData.lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * bulletData.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the hit object is on the Enemy layer
        if ((enemyLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            // Try to deal damage if it has an Enemy component
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletData.damage);
            }

            Destroy(gameObject);
        }
    }
}
