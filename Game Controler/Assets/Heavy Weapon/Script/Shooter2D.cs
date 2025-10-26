using UnityEngine;

public class Shooter2D : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootCooldown = 0.2f;

    private float lastShootTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        lastShootTime = Time.time;
    }
}
