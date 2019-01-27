using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] WeaponInterface tempWeaponInterface;
    [SerializeField] WeaponInterface weaponInterface;

    Coroutine shootCoroutine = null;

    bool firing;
    float weaponFiringSpeed;

    float recoilDecay = 1;

    [FMODUnity.EventRef]
    [SerializeField]
    string shotSound = "event:/SFXs/Regular Shot";
    FMOD.Studio.EventInstance shotEvent;

    [FMODUnity.EventRef]
    [SerializeField]
    string spreadShotSound = "event:/SFXs/Spread Shot";
    FMOD.Studio.EventInstance spreadShotEvent;

    // Use this for initialization
    void Start ()
    {
        shotEvent = FMODUnity.RuntimeManager.CreateInstance(shotSound);
        spreadShotEvent = FMODUnity.RuntimeManager.CreateInstance(spreadShotSound);
        tempWeaponInterface = null;
        SetDefaultWeaponInterface();
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

    public void SetDefaultWeaponInterface()
    {
        weaponInterface = new WeaponType0();
    }

    public void SetTemporaryInterface(WeaponInterface wInterface)
    {
        tempWeaponInterface = wInterface;
    }

    public void SetInterface()
    {
        if (tempWeaponInterface != null)
        {
            Debug.Log("Weapon Type = " + tempWeaponInterface);
            weaponInterface = tempWeaponInterface;
            weaponFiringSpeed = weaponInterface.GetFiringSpeed();
            weaponInterface.Reload();
            tempWeaponInterface = null;
        }
    }

    public WeaponInterface GetWeaponInterface()
    {
        return weaponInterface;
    }

    public WeaponInterface GetTempWeaponInterface()
    {
        return tempWeaponInterface;
    }

    public ProjectileInterface GetProjectileInterface()
    {
        return weaponInterface.GetWeaponProjectileInterface();
    }

    IEnumerator CallShoot()
    {
        Debug.Log("Firing Weapon: " + weaponInterface);
        player.AddForce(transform.up * -1 * weaponInterface.GetRecoil());
        weaponInterface.Shoot(transform);
        if (weaponInterface.ToString() == "WeaponType2" || weaponInterface.ToString() == "WeaponType5" || weaponInterface.ToString() == "WeaponType7" || weaponInterface.ToString() == "WeaponType8" || weaponInterface.ToString() == "WeaponType13")
        {
            spreadShotEvent.start();
        }
        else
        {
            shotEvent.start();
        }
        if (weaponInterface.GetAmmo() == 0)
        {
            SetDefaultWeaponInterface();
        }
        yield return new WaitForSeconds(weaponFiringSpeed);
        firing = false;
    }
}
