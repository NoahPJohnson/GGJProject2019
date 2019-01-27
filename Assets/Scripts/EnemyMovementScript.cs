using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
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
    // Use this for initialization
    void Start ()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        guideVector = (transform.position - playerReference.position).normalized*-1;
        //Debug.Log("Guide Vector: " + guideVector);
        guideRotation = Mathf.Atan2(guideVector.x, guideVector.y)*Mathf.Rad2Deg;
        //Debug.Log("From to Rotation = " + Quaternion.FromToRotation(Vector2.up, guideVector).eulerAngles);
        //Debug.Log("Guide Rotation: " + guideRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-guideRotation), turnSpeed * Time.deltaTime);

        enemyRigidbody.MovePosition(enemyRigidbody.position + ((Vector2)transform.up * moveSpeed) * Time.deltaTime);
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
