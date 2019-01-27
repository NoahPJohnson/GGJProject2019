using System.Collections;
using UnityEngine;

public abstract class WeaponInterface
{
    protected GameObject projectile;
    protected ProjectileInterface weaponProjectileInterface;
    protected float firingSpeed;
    protected float recoil;
    public GameObject GetProjectile() { return projectile; }
    public ProjectileInterface GetWeaponProjectileInterface() { return weaponProjectileInterface; }
    public float GetFiringSpeed() { return firingSpeed;  }
    public float GetRecoil() { return recoil; }
    public abstract void Shoot(Transform startTransform);
	
}
