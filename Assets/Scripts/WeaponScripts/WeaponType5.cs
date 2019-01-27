using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType5 : WeaponInterface
{
    //SPREAD UPGRADE 2
    public WeaponType5()
    {
        this.firingSpeed = 0.8f;
        this.recoil = 2300;
        this.ammo = 12;
        this.maxAmmo = ammo;
        this.projectile = (GameObject)Resources.Load("Projectile0");
        this.weaponProjectileInterface = new ProjectileType0();
    }
    public override void Shoot(Transform sTransform)
    {
        //Debug.Log("Spread Bang!");
        if (ammo > 0)
        {
            projectile.GetComponent<ProjectileScript>().SetInterface(weaponProjectileInterface);
            GameObject.Instantiate(projectile, sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + new Vector2(0.1f, 0), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -25)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + new Vector2(0.3f, 0), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -50)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + new Vector2(-0.1f, 0), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 25)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + new Vector2(-0.3f, 0), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 50)), sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
