using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] float moveSpeed;


    Vector2 guideVector;
    float guideRotation;

    [SerializeField] Vector2 moveVector;

    [SerializeField] Rigidbody2D enemyRigidbody;


    //[SerializeField] Transform playerWeapon;

    //Collision Stuff
    int hCollision = 1;
    int vCollision = 1;

    Vector2 oldNormal;

    [SerializeField] Transform playerReference;

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    // Use this for initialization
    void Start ()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
        RandomizeEnemyStats();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerReference.GetComponent<PlayerDamageScript>().GetCurrentHP() <= 0)
        {
            GetComponent<EnemyDamageScript>().EnemyHPZero();
        }
        guideVector = (playerReference.position - transform.position).normalized;
        if (guideVector.magnitude > 0.1)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        moveVector.Set(guideVector.x * hCollision, guideVector.y * vCollision);

        enemyRigidbody.MovePosition(enemyRigidbody.position + ((Vector2)moveVector * moveSpeed) * Time.deltaTime);

        if (hCollision == 0)
        {
            if (guideVector.x > 0 && oldNormal.x > 0)
            {
                hCollision = 1;
            }
            if (guideVector.x < 0 && oldNormal.x < 0)
            {
                hCollision = 1;
            }
            //Debug.Log("The input vector = " + inputVector);
        }
        if (vCollision == 0)
        {
            if (guideVector.y > 0 && oldNormal.y > 0)
            {
                vCollision = 1;
            }
            if (guideVector.y < 0 && oldNormal.y < 0)
            {
                vCollision = 1;
            }
        }
    }

    public Vector2 GetGuideVector()
    {
        return guideVector;
    }

    void RandomizeEnemyStats()
    {
        moveSpeed = Random.Range(4.0f, 6.5f);
        transform.GetChild(0).GetComponent<EnemyRotationScript>().SetTurnSpeed((Random.Range(12.0f, 14.5f))*10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            if (other.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectileStationary() == true)
            {
                GetComponent<EnemyDamageScript>().EnemyTakeDamage(other.gameObject.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectileDamage(), other.gameObject.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectilePushback());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            if (other.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectileStationary() == true)
            {
                GetComponent<EnemyDamageScript>().EnemyTakeDamage(other.gameObject.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectileDamage(), other.gameObject.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectilePushback());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Projectile")
        {
            GetComponent<EnemyDamageScript>().EnemyTakeDamage(other.gameObject.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectileDamage(), other.gameObject.GetComponent<ProjectileScript>().GetProjectileInterface().GetProjectilePushback());
            GameObject.Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Wall")
        {
            //Debug.Log("Input Vector = " + inputVector + " The normal = " + other.contacts[0].normal);
            if (other.contacts[0].normal.x != 0)
            {
                if (guideVector.x > 0 && other.contacts[0].normal.x < 0)
                {
                    //Debug.Log("Horizontal Collision Right");
                    oldNormal = other.contacts[0].normal;
                    hCollision = 0;
                }
                else if (guideVector.x < 0 && other.contacts[0].normal.x > 0)
                {
                    //Debug.Log("Horizontal Collision Left");
                    oldNormal = other.contacts[0].normal;
                    hCollision = 0;
                }
                else
                {
                    //Debug.Log("Away from wall. H");
                    //hCollision = 1;
                }

            }
            else
            {
                //Debug.Log("Normal = 0: H ");
                hCollision = 1;
            }
            if (other.contacts[0].normal.y != 0)
            {
                if (guideVector.y > 0 && other.contacts[0].normal.y < 0)
                {
                    //Debug.Log("Vertical Collision Up");
                    oldNormal = other.contacts[0].normal;
                    vCollision = 0;
                }
                else if (guideVector.y < 0 && other.contacts[0].normal.y > 0)
                {
                    //Debug.Log("Vertical Collision Down");
                    oldNormal = other.contacts[0].normal;
                    vCollision = 0;
                }
                else
                {
                    //Debug.Log("Away from wall. V");
                    //vCollision = 1;
                }
            }
            else
            {
                //Debug.Log("Normal = 0: V ");
                vCollision = 1;
            }

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Wall")
        {
            if (hCollision == 0)
            {
                hCollision = 1;
            }
            if (vCollision == 0)
            {
                vCollision = 1;
            }

        }
    }
}
