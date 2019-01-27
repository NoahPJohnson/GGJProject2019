using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] WeaponInterface weaponInterface;

    Coroutine shootCoroutine = null;

    bool firing;
    float weaponFiringSpeed;

    float recoilDecay = 1;

	// Use this for initialization
	void Start ()
    {
        SetInterface(new WeaponType0());
        firing = false;
        weaponFiringSpeed = weaponInterface.GetFiringSpeed();
        //Debug.Log("Firing Speed = " + weaponFiringSpeed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetAxis("Fire1") > 0.3 && firing == false)
        {
            shootCoroutine = StartCoroutine("CallShoot");
            firing = true;
        }
	}

    public void SetInterface(WeaponInterface wInterface)
    {
        weaponInterface = wInterface;
        weaponFiringSpeed = weaponInterface.GetFiringSpeed();
    }

    public ProjectileInterface GetProjectileInterface()
    {
        return weaponInterface.GetWeaponProjectileInterface();
    }

    IEnumerator CallShoot()
    {
        
        player.AddForce(transform.up * -1 * weaponInterface.GetRecoil());
        weaponInterface.Shoot(transform);
        yield return new WaitForSeconds(weaponFiringSpeed);
        firing = false;
    }
}
