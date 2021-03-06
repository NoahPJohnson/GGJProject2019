﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    [SerializeField] ProjectileInterface projectileInterface;

    [SerializeField] float pSpeed;
    [SerializeField] float pRange;
    [SerializeField] float pDamage;

    float timer = 0;


	// Use this for initialization
	void Start ()
    {
        if (transform.parent.GetComponent<WeaponScript>() != null)
        {
            SetInterface(transform.parent.GetComponent<WeaponScript>().GetProjectileInterface());
        }
        if (projectileInterface.GetProjectileStationary() == false)
        {
            transform.parent = null;
        }
        projectileInterface.CreateProjectile();
        pSpeed = projectileInterface.GetProjectileSpeed();
        pRange = projectileInterface.GetProjectileRange();
        pDamage = projectileInterface.GetProjectileDamage();
        timer = 0;
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * pSpeed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (projectileInterface.GetProjectileStationary() == false)
        {
            transform.Translate(Vector2.up * pSpeed * Time.deltaTime);
        }
        if (projectileInterface.GetPRojectileActive() == false)
        {
            //Debug.Log("Active is False");
            GameObject.Destroy(gameObject);
        }

        timer += Time.deltaTime;
        if (timer > pRange)
        {
            GameObject.Destroy(gameObject);
        }

	}

    public void SetInterface(ProjectileInterface pInterface)
    {
        projectileInterface = pInterface;
    }

    public ProjectileInterface GetProjectileInterface()
    {
        return projectileInterface;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Wall")
        {
            projectileInterface.WallHit();
            if (projectileInterface.GetProjectileBounce() == true)
            {
                //Debug.Log("Bounce off wall!");
                //Debug.Log("Transform Up Before = " + transform.rotation.eulerAngles);
                Vector2 tempVector = Vector2.Reflect((transform.rotation * Vector2.up), other.contacts[0].normal);
                transform.rotation = Quaternion.Euler(0,0,(Mathf.Atan2(tempVector.y,tempVector.x)*Mathf.Rad2Deg)-90);
                //Debug.Log("Transform Up After = " + transform.rotation.eulerAngles);
                //transform.forward = Vector3.Scale(transform.forward, lockVector);
            }
            if (projectileInterface.GetProjectileSplit() == true)
            {
                GameObject subProjectile = (GameObject)Resources.Load("Projectile0");
                subProjectile.GetComponent<ProjectileScript>().SetInterface(new ProjectileType2());
                Quaternion subPRotation = Quaternion.Euler(0, 0, (Mathf.Atan2(other.contacts[0].normal.y, other.contacts[0].normal.x) * Mathf.Rad2Deg) - 90);
                float rotationVariation = Random.Range(-45.0f, 45.0f);
                GameObject.Instantiate(subProjectile, transform.position, subPRotation * Quaternion.Euler(0,0,rotationVariation), transform);
                    
            }
        }

    }
}
