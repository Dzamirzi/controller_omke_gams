using UnityEngine;

public class SlideSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject prefab;
    public float spawnInterval = 2f;
    public Vector3 spawnPosition = new Vector3(5f, 0f, 0f);

    [Header("Slide Settings")]
    public float slideSpeed = 2f;
    public float lifetime = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSlidingObject();
            timer = 0f;
        }
    }

    void SpawnSlidingObject()
    {
        GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // Add a simple movement + destroy component on the fly
        SlideAndDestroy behavior = obj.AddComponent<SlideAndDestroy>();
        behavior.speed = slideSpeed;
        behavior.lifetime = lifetime;
    }
}

public class SlideAndDestroy : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
