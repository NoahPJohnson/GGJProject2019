using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] float enemyMaxHP = 100;
    [SerializeField] float enemyCurrentHP;

    

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        enemyCurrentHP = enemyMaxHP;
	}

    public void EnemyTakeDamage(float damageValue, float pushBack)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.GetChild(0).up * -1 * pushBack);
        enemyCurrentHP -= damageValue;
        if (enemyCurrentHP <= 0)
        {
            EnemyHPZero();
        }
        
    }

    public void EnemyHPZero()
    {
        StartCoroutine("EnemyDeath");
    }

    IEnumerator EnemyDeath()
    {
        anim.SetTrigger("Die");
        transform.parent.GetComponent<EnemySpawnerScript>().RemoveEnemy();
        yield return new WaitForSeconds(1.0f);
        GameObject.Destroy(gameObject);
    }
}
