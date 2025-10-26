using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    private float currentHealth;

    private void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! Remaining HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died!");
        Destroy(gameObject);
    }
}
