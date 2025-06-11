using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value);
            Destroy(gameObject);
        }
    }
}
