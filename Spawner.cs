using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject[] possiblePrefabs;
    public float spawnCooldown = 1f;
    public float delayToStartSpawning = 1f;

    void Start()
    {
        InvokeRepeating("Spawn", delayToStartSpawning, spawnCooldown);
    }

    void Spawn ()
    {
        int enemyIndex = Random.Range(0, possiblePrefabs.Length);
        Instantiate(possiblePrefabs[enemyIndex], transform.position, Quaternion.identity);
    }
}
