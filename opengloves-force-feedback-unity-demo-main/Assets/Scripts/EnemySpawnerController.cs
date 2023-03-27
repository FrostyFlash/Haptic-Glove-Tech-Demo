using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 4;
    private int currentEnemies = 0;
    private bool isSpawning = true;
    public float spawnDelay = 5f;

    IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            if (currentEnemies < maxEnemies)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                currentEnemies++;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (currentEnemies == 0)
        {
            isSpawning = true;
        }
        else if (currentEnemies >= maxEnemies)
        {
            isSpawning = false;
        }
    }

    void OnEnemyDestroyed()
    {
        currentEnemies--;
    }
}
