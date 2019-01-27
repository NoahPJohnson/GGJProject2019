using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType7 : WeaponInterface
{
    //NORMAL + SPREAD UPGRADE
    public WeaponType7()
    {
        this.firingSpeed = 0.5f;
        this.recoil = 1800;
        this.ammo = 15;
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
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + new Vector2(0.2f, 0), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -30)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + new Vector2(-0.2f, 0), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 30)), sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
