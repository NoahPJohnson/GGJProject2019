using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggerScript : MonoBehaviour {

    [SerializeField] Transform fogOfWar;
    [SerializeField] Transform doors;
    [SerializeField] Transform enemySpawner;

    bool roomActive = false;
    float doorOpenTime = 5;
    float timer;

	// Use this for initialization
	void Start ()
    {
        fogOfWar = transform.parent.GetChild(1);
        doors = transform.parent.GetChild(2);
        enemySpawner = transform.parent.GetChild(3);
        fogOfWar.gameObject.SetActive(true);
        doors.gameObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (roomActive == true)
        {
            if (enemySpawner.GetComponent<EnemySpawnerScript>().GetSpawnedEnemiesCount() <= 0)
            {
                DoorsOpen();
            }
            /*timer += Time.deltaTime;
            if (timer > doorOpenTime)
            {
                DoorsOpen();
            }*/
        }
	}

    public void RoomExit()
    {
        enemySpawner.GetComponent<EnemySpawnerScript>().StopSpawning();
    }

    public void RoomEnter()
    {
        roomActive = true;
        timer = 0;
        fogOfWar.gameObject.SetActive(false);
        doors.gameObject.SetActive(true);
        enemySpawner.GetComponent<EnemySpawnerScript>().SpawnEnemy();
    }

    public void DoorsOpen()
    {
        roomActive = false;
        doors.gameObject.SetActive(false);
    }
}
