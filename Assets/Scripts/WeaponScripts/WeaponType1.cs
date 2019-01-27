using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType1 : WeaponInterface
{
    public WeaponType1()
    {
        this.firingSpeed = 0.4f;
        this.recoil = 1500;
        this.ammo = 12;
        this.maxAmmo = ammo;
        this.projectile = (GameObject)Resources.Load("Projectile0");
        this.weaponProjectileInterface = new ProjectileType1();
    }
    public override void Shoot(Transform sTransform)
    {
        //Debug.Log("NEW Bang!");
        if (ammo > 0)
        {
            projectile.GetComponent<ProjectileScript>().SetInterface(weaponProjectileInterface);
            GameObject.Instantiate(projectile, sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
