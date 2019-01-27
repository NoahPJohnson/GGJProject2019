using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType14 : WeaponInterface
{
    //BOUNCE UPGRADE 2
    public WeaponType14()
    {
        this.firingSpeed = 0.6f;
        this.recoil = 800;
        this.ammo = 35;
        this.maxAmmo = ammo;
        this.projectile = (GameObject)Resources.Load("Projectile0");
        this.weaponProjectileInterface = new ProjectileType5();
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
