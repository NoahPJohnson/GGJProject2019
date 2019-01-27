using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageScript : MonoBehaviour
{
    float maxHp = 100;
    float currentHP;
    GameObject[] homes = new GameObject[2];
    GameObject[] enemiesLeftOver = new GameObject[100];

    Transform returnPoint;
	// Use this for initialization
	void Start ()
    {
        currentHP = maxHp;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public float GetCurrentHP()
    {
        return currentHP;
    }

    public void ResetHP()
    {
        currentHP = maxHp;
    }

    public void TakeDamage(float damageValue)
    {
        currentHP -= damageValue;
        GetComponent<Rigidbody2D>().AddForce(transform.up * -1 * 1800);
        Debug.Log("Damage! HP = " + currentHP);
        if (currentHP <= 0)
        {
            HealthZero();
        }
    }

    public void HealthZero()
    {
        
        homes = GameObject.FindGameObjectsWithTag("HomeTrigger");
        for (int i = 0; i < 2; i++)
        {
            if (homes[i].GetComponent<HomeTriggerScript>().GetDestination() == false)
            {
                returnPoint = homes[i].transform;
            }
        }
        transform.position = returnPoint.position;
        GetComponent<PlayerMovement>().GetWeapon().GetComponent<WeaponScript>().SetDefaultWeaponInterface();
        GetComponent<PlayerMovement>().GetWeapon().GetComponent<WeaponScript>().SetTemporaryInterface(new WeaponType0());
    }
}
