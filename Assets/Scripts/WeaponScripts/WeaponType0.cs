using System.Collections;

using UnityEngine;

public class WeaponType0 : WeaponInterface
{
    public WeaponType0() 
    {
        this.firingSpeed = 0.7f;
        this.recoil = 1000;
        this.ammo = -1;
        this.maxAmmo = ammo;
        this.projectile = (GameObject)Resources.Load("Projectile0");
        this.weaponProjectileInterface = new ProjectileType0();
    }
    public override void Shoot(Transform sTransform)
    {
        //Debug.Log("Bang!");
        projectile.GetComponent<ProjectileScript>().SetInterface(weaponProjectileInterface);
        GameObject.Instantiate(projectile, sTransform);
        //firedProjectile.transform.parent = null;
    }
}
