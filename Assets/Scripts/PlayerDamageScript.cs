using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageScript : MonoBehaviour
{
    float maxHp = 100;
    float currentHP;
	// Use this for initialization
	void Start ()
    {
        currentHP = maxHp;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TakeDamage(float damageValue)
    {
        currentHP -= damageValue;
        GetComponent<Rigidbody2D>().AddForce(transform.up * -1 * 1800);
        Debug.Log("Damage! HP = " + currentHP);
    }
}
