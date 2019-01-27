using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType9 : WeaponInterface
{
    //BOUNCE + NORMAL UPGRADE
    public WeaponType9()
    {
        this.firingSpeed = 0.4f;
        this.recoil = 900;
        this.ammo = 15;
        this.maxAmmo = ammo;
        this.projectile = (GameObject)Resources.Load("Projectile0");
        this.weaponProjectileInterface = new ProjectileType2();
    }
    public override void Shoot(Transform sTransform)
    {
        //Debug.Log("Bounce Bang!");
        if (ammo > 0)
        {
            projectile.GetComponent<ProjectileScript>().SetInterface(weaponProjectileInterface);
            GameObject.Instantiate(projectile, sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
