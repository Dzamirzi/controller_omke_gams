using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "Data/Bullet Data")]
public class BulletData : ScriptableObject
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifetime = 2f;
    public float damage = 10f;
}
