using System.Collections;
using UnityEngine;

public abstract class ProjectileInterface
{
    protected bool projectileActive;
    protected bool projectileBounce = false;
    protected bool projectileStationary = false;
    protected bool projectileSplit = false;
    protected bool subProjectile = false;
    protected int projectileBounces;
    protected float projectileSpeed;
    protected float projectileRange;
    protected float projectileDamage;
    protected float projectilePushback;
    public bool GetPRojectileActive() { return projectileActive; }
    public bool GetProjectileBounce() { return projectileBounce; }
    public bool GetProjectileStationary() { return projectileStationary; }
    public bool GetProjectileSplit() { return projectileSplit; }
    public bool GetProjectileSub() { return subProjectile; }
    public int GetProjectileBounces() { return projectileBounces; }
    public float GetProjectileSpeed() { return projectileSpeed; }
    public float GetProjectileRange() { return projectileRange; }
    public float GetProjectileDamage() { return projectileDamage; }
    public float GetProjectilePushback() { return projectilePushback; }
    public abstract void CreateProjectile();
    public abstract void WallHit();
    public abstract void EnemyHit();
}
