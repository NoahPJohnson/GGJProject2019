using System.Collections;
using UnityEngine;

public abstract class WeaponInterface
{
    protected GameObject projectile;
    protected ProjectileInterface weaponProjectileInterface;
    protected float firingSpeed;
    protected float recoil;
    protected int ammo;
    protected int maxAmmo;
    public GameObject GetProjectile() { return projectile; }
    public ProjectileInterface GetWeaponProjectileInterface() { return weaponProjectileInterface; }
    public float GetFiringSpeed() { return firingSpeed;  }
    public float GetRecoil() { return recoil; }
    public int GetAmmo() { return ammo; }
    public int GetMaxAmmo() { return maxAmmo; }
    public void Reload() { ammo = maxAmmo; }
    public abstract void Shoot(Transform startTransform);
	
}
