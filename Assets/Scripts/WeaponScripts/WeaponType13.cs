using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType13 : WeaponInterface
{
    //SPREAD UPGRADE 3 (Proximity)
    public WeaponType13()
    {
        this.firingSpeed = 0.8f;
        this.recoil = 1100;
        this.ammo = 28;
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
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.1f) - ((Vector2)sTransform.up * 0.0f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -25)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.3f) - ((Vector2)sTransform.up * 0.2f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -50)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.5f) - ((Vector2)sTransform.up * 0.4f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -75)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * -0.1f) - ((Vector2)sTransform.up * 0.0f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 25)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * -0.3f) - ((Vector2)sTransform.up * 0.2f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 50)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * -0.5f) - ((Vector2)sTransform.up * 0.4f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 75)), sTransform);

            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.0f) - ((Vector2)sTransform.up * 1.0f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 180)), sTransform);

            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.5f) - ((Vector2)sTransform.up * 0.6f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -105)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.3f) - ((Vector2)sTransform.up * 0.8f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -130)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * 0.1f) - ((Vector2)sTransform.up * 1.0f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, -155)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * -0.5f) - ((Vector2)sTransform.up * 0.6f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 105)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * -0.3f) - ((Vector2)sTransform.up * 0.8f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 130)), sTransform);
            GameObject.Instantiate(projectile, (Vector2)sTransform.position + ((Vector2)sTransform.right * -0.1f) - ((Vector2)sTransform.up * 1.0f), sTransform.rotation * Quaternion.Euler(new Vector3(0, 0, 155)), sTransform);
            ammo -= 1;
        }
        //firedProjectile.transform.parent = null;
    }
}
