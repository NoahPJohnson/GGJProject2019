using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    [SerializeField] float enemyMaxHP = 100;
    [SerializeField] float enemyCurrentHP;

	// Use this for initialization
	void Start ()
    {
        enemyCurrentHP = enemyMaxHP;
	}

    public void EnemyTakeDamage(float damageValue, float pushBack)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * -1 * pushBack);
        enemyCurrentHP -= damageValue;
        if (enemyCurrentHP <= 0)
        {
            GameObject.Destroy(gameObject);
            transform.parent.GetComponent<EnemySpawnerScript>().RemoveEnemy();
        }
        
    }
}
