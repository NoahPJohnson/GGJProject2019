using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType12 : WeaponInterface
{
    //Temp Normal Upgrade 3 GATLING
    public WeaponType12()
    {
        this.firingSpeed = 0.05f;
        this.recoil = 700;
        this.ammo = 120;
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
            float randomRotation = Random.Range(-9.0f, 9.0f);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position, sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, randomRotation)), sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
