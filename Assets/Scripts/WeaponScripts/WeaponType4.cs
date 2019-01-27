using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType4 : WeaponInterface
{
    //NORMAL UPGRADE 2
    public WeaponType4()
    {
        this.firingSpeed = 0.1f;
        this.recoil = 1700;
        this.ammo = 24;
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
