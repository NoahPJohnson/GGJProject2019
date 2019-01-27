using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] int spawnLevel;
    [SerializeField] ArrayList SpawnedEnemies = new ArrayList();

	// Use this for initialization
	void Start ()
    {
        spawnLevel = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SpawnEnemy()
    {
        if (spawnLevel < 1)
        {
            spawnLevel += 1;
            SpawnedEnemies.Add(GameObject.Instantiate(enemyToSpawn, transform));
        }
    }

    public void RemoveEnemy()
    {
        if (SpawnedEnemies.Count > 0)
        {
            SpawnedEnemies.RemoveAt(SpawnedEnemies.Count - 1);
        }
    }

    public int GetSpawnedEnemiesCount()
    {
        return SpawnedEnemies.Count;
    }
}
