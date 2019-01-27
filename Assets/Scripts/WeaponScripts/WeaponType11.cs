using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType11 : WeaponInterface
{
    public WeaponType11()
    {
        this.firingSpeed = 2.5f;
        this.recoil = 1100;
        this.ammo = 26;
        this.maxAmmo = ammo;
        this.projectile = (GameObject)Resources.Load("Projectile1");
        this.weaponProjectileInterface = new ProjectileType4();
    }
    public override void Shoot(Transform sTransform)
    {
        //Debug.Log("NEW Bang!");
        if (ammo > 0)
        {
            projectile.GetComponent<ProjectileScript>().SetInterface(weaponProjectileInterface);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.up*3), sTransform.rotation, sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
