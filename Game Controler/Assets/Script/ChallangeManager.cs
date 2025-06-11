using System.Collections.Generic;
using UnityEngine;

public class ChallengerManager : MonoBehaviour
{
    [Header("Challenge Settings")]
    public List<GameObject> challengePrefabs; // List of challenge prefabs
    public Transform spawnPoint;
    public Transform destroyPoint;
    public float spawnInterval = 2f;
    public float moveSpeed = 5f;

    private float spawnTimer = 0f;

    private List<GameObject> activeChallenges = new List<GameObject>();

    void Update()
    {
        // Spawn logic
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnChallenge();
            spawnTimer = 0f;
        }

        // Move & destroy challenges
        for (int i = activeChallenges.Count - 1; i >= 0; i--)
        {
            GameObject challenge = activeChallenges[i];
            if (challenge == null)
            {
                activeChallenges.RemoveAt(i);
                continue;
            }

            // Move
            challenge.transform.position = Vector3.MoveTowards(
                challenge.transform.position,
                destroyPoint.position,
                moveSpeed * Time.deltaTime
            );

            // Destroy if passed
            if (Vector3.Distance(challenge.transform.position, destroyPoint.position) < 0.1f)
            {
                Destroy(challenge);
                activeChallenges.RemoveAt(i);
            }
        }
    }

    void SpawnChallenge()
    {
        if (challengePrefabs.Count == 0) return;

        int randomIndex = Random.Range(0, challengePrefabs.Count);
        GameObject prefab = challengePrefabs[randomIndex];
        GameObject newChallenge = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        activeChallenges.Add(newChallenge);
    }
}
