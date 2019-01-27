using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType1 : WeaponInterface
{
    public WeaponType1()
    {
        this.firingSpeed = 0.4f;
        this.recoil = 1500;
        this.projectile = (GameObject)Resources.Load("Projectile0");
        this.weaponProjectileInterface = new ProjectileType1();
    }
    public override void Shoot(Transform sTransform)
    {
        //Debug.Log("NEW Bang!");
        projectile.GetComponent<ProjectileScript>().SetInterface(weaponProjectileInterface);
        GameObject.Instantiate(projectile, sTransform);
        //firedProjectile.transform.parent = null;
    }
}
