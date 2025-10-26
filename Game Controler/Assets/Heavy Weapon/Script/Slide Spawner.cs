using UnityEngine;

public class ObjectSpawnerMover : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] prefabsToSpawn;
    public Transform pointA;
    public Transform pointB;

    [Header("Interval Settings")]
    [Tooltip("Base spawn interval (seconds) before applying intensity multiplier")]
    public float baseSpawnInterval = 2f;
    [Tooltip("Minimum allowed interval (seconds)")]
    public float minSpawnInterval = 0.3f;

    [Header("Intensity (spawn rate increases over time)")]
    [Tooltip("How fast spawn rate increases over time")]
    public float intensityGrowthRate = 0.05f; // e.g., +5% per second
    private float spawnRateMultiplier = 1f;

    [Header("Movement Settings")]
    public float minSpeed = 3f;
    public float maxSpeed = 8f;
    public float randomHeightRange = 1f;

    [Header("Debug")]
    public bool showDebug = true;

    private float nextSpawnTime;
    private float startTime;

    void Start()
    {
        if (prefabsToSpawn == null || prefabsToSpawn.Length == 0)
            Debug.LogWarning("No prefabs assigned to ObjectSpawnerMover!");

        startTime = Time.time;
        nextSpawnTime = Time.time + baseSpawnInterval;
    }

    void Update()
    {
        float elapsed = Time.time - startTime;

        // Increase spawn rate over time (exponential feel)
        spawnRateMultiplier = 1f + elapsed * intensityGrowthRate;

        // Compute current interval based on rate
        float currentInterval = Mathf.Max(baseSpawnInterval / spawnRateMultiplier, minSpawnInterval);

        if (Time.time >= nextSpawnTime)
        {
            SpawnAndMove();
            nextSpawnTime = Time.time + currentInterval;

            if (showDebug)
            {
                Debug.Log($"[Spawner] Time={Time.time:F2} Elapsed={elapsed:F2} Rate={spawnRateMultiplier:F2} Interval={currentInterval:F3}");
            }
        }
    }

    void SpawnAndMove()
    {
        if (prefabsToSpawn == null || prefabsToSpawn.Length == 0 || pointA == null || pointB == null)
        {
            Debug.LogWarning("Missing prefabs or points in ObjectSpawnerMover!");
            return;
        }

        // pick random prefab
        GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        // choose direction A->B or B->A
        bool directionAB = Random.value > 0.5f;
        Transform startPoint = directionAB ? pointA : pointB;
        Transform endPoint = directionAB ? pointB : pointA;

        // spawn with random Y offset
        Vector3 spawnPos = startPoint.position;
        spawnPos.y += Random.Range(-randomHeightRange, randomHeightRange);

        GameObject obj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        // random speed
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // add mover component
        Mover mover = obj.AddComponent<Mover>();
        mover.Initialize(endPoint.position, randomSpeed, randomHeightRange);
    }

    public void ResetIntensity()
    {
        startTime = Time.time;
        spawnRateMultiplier = 1f;
    }
}

public class Mover : MonoBehaviour
{
    private Vector3 target;
    private float speed;

    public void Initialize(Vector3 targetPosition, float moveSpeed, float heightRange)
    {
        target = targetPosition;
        target.y += Random.Range(-heightRange, heightRange);
        speed = moveSpeed;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
            Destroy(gameObject);
    }
}
