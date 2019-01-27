using System.Collections;
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
        SetInterface(transform.parent.GetComponent<WeaponScript>().GetProjectileInterface());
        transform.parent = null;
        projectileInterface.CreateProjectile();
        pSpeed = projectileInterface.GetProjectileSpeed();
        pRange = projectileInterface.GetProjectileRange();
        pDamage = projectileInterface.GetProjectileDamage();
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * pSpeed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.up * pSpeed * Time.deltaTime);

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
        }

    }
}
