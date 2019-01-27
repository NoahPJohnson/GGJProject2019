using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType3 : WeaponInterface
{
    public WeaponType3()
    {
        this.firingSpeed = 0.6f;
        this.recoil = 800;
        this.ammo = 12;
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
