using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] int spawnLevel;
    [SerializeField] ArrayList SpawnedEnemies = new ArrayList();

    bool spawning = false;
    int spawnCount = 0;

	// Use this for initialization
	void Start ()
    {
        spawnLevel = 0;
        spawnCount = transform.childCount;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SpawnEnemy()
    {
        if (spawnLevel < 3 && spawning == false)
        {
            spawnLevel += 1;
            spawning = true;
            for (int i = 0; i < spawnLevel; i++)
            {
                for (int j = 0; j < spawnCount; j++)
                {
                    //Debug.Log("Spawn Enemy Index = " + j);
                    SpawnedEnemies.Add(GameObject.Instantiate(enemyToSpawn, transform.GetChild(j).transform.position+new Vector3(i,i,0), transform.GetChild(j).transform.rotation, transform));
                }
            }
        }
    }

    public void StopSpawning()
    {
        spawning = false;
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
