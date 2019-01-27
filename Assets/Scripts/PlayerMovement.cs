using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed
    [SerializeField] float moveSpeed;
    Vector2 inputVector;
    [SerializeField] Vector2 moveVector;

    [SerializeField] Rigidbody2D playerRigidbody;

    [SerializeField] Transform playerWeapon;

    //Collision Stuff
    int hCollision = 1;
    int vCollision = 1;

    Vector2 oldNormal;

    //Damage
    int damageIndex = 0;
    ArrayList enemyAttacksList = new ArrayList(); 
    ArrayList damageCoroutineList = new ArrayList();

    // Use this for initialization
    void Start ()
    {
        damageIndex = 0;
        playerRigidbody = GetComponent<Rigidbody2D>();
        enemyAttacksList.Add(null);
        damageCoroutineList.Add(null);
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputVector.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVector.Set(inputVector.x * hCollision, inputVector.y * vCollision);
        playerRigidbody.MovePosition(playerRigidbody.position + (moveVector * moveSpeed) * Time.deltaTime);
        //playerRigidbody.MovePosition(playerRigidbody.position + (new Vector2(0, -25)) * Time.deltaTime);
            //transform.Translate(moveVector * moveSpeed * Time.deltaTime);

            if (hCollision == 0)
        {
            if (inputVector.x > 0 && oldNormal.x > 0)
            {
                hCollision = 1;
            }
            if (inputVector.x < 0 && oldNormal.x < 0)
            {
                hCollision = 1;
            }
            //Debug.Log("The input vector = " + inputVector);
        }
        if (vCollision == 0)
        {
            if (inputVector.y > 0 && oldNormal.y > 0)
            {
                vCollision = 1;
            }
            if (inputVector.y < 0 && oldNormal.y < 0)
            {
                vCollision = 1;
            }
        }
    }

    public void PlayerRecoil(Vector2 recoilDirection, float recoilForce, bool weaponFiring)
    {
        playerRigidbody.MovePosition(playerRigidbody.position + (recoilDirection * recoilForce) * Time.deltaTime);
        //Debug.Log("Player move by: " + recoilDirection * recoilForce);
    }

    IEnumerator DamageCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<PlayerDamageScript>().TakeDamage(20);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Upgrade")
        {
            playerWeapon.GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
            playerWeapon.GetComponent<WeaponScript>().SetInterface(other.GetComponent<UpgradeScript>().GetUpgradeWeapon());
            GameObject.Destroy(other.gameObject);
        }
        if (other.tag == "RoomTrigger")
        {
            other.GetComponent<RoomTriggerScript>().RoomEnter();
        }
        if (other.tag == "Hitbox")
        {
            if (other.gameObject != (GameObject)enemyAttacksList[enemyAttacksList.Count-1])
            {
                damageCoroutineList.Add(StartCoroutine("DamageCoroutine"));
                enemyAttacksList.Add(other.gameObject);
                //damageIndex += 1;
                /*for (int i = 0; i < enemyAttacksList.Count; i++)
                {
                    Debug.Log("Enemy Attacks List: " + enemyAttacksList[i]);
                    Debug.Log("Damage Coroutine List: " + damageCoroutineList[i].ToString());
                }*/
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hitbox")
        {
            //Debug.Log("LEAVE.");
            for (int i = 0; i <= enemyAttacksList.Count; i++)
            {
                //Debug.Log("Enemy Attack: " + i + " = " + (GameObject)enemyAttacksList[i]);
                if (other.gameObject == (GameObject)enemyAttacksList[i])
                {
                    //Debug.Log("Exit hitbox stop coroutine.");
                    StopCoroutine((Coroutine)damageCoroutineList[i]);
                    damageCoroutineList.RemoveAt(i);
                    enemyAttacksList.RemoveAt(i);
                    for (int j = i+1; j < enemyAttacksList.Count; j++)
                    {
                        damageCoroutineList[i] = damageCoroutineList[j];
                        enemyAttacksList[i] = enemyAttacksList[j];
                        damageCoroutineList.RemoveAt(j);
                        enemyAttacksList.RemoveAt(j);
                    }
                    break;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Wall")
        {
            //Debug.Log("Input Vector = " + inputVector + " The normal = " + other.contacts[0].normal);
            if (other.contacts[0].normal.x != 0)
            {
                if (inputVector.x > 0 && other.contacts[0].normal.x < 0)
                {
                    //Debug.Log("Horizontal Collision Right");
                    oldNormal = other.contacts[0].normal;
                    hCollision = 0;
                }
                else if (inputVector.x < 0 && other.contacts[0].normal.x > 0)
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
                if (inputVector.y > 0 && other.contacts[0].normal.y < 0)
                {
                    //Debug.Log("Vertical Collision Up");
                    oldNormal = other.contacts[0].normal;
                    vCollision = 0;
                }
                else if (inputVector.y < 0 && other.contacts[0].normal.y > 0)
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
