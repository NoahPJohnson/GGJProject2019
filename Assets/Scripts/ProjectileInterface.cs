using System.Collections;
using UnityEngine;

public abstract class ProjectileInterface
{
    protected bool projectileActive;
    protected float projectileSpeed;
    protected float projectileRange;
    protected float projectileDamage;
    protected float projectilePushback;
    public bool GetPRojectileActive() { return projectileActive; }
    public float GetProjectileSpeed() { return projectileSpeed; }
    public float GetProjectileRange() { return projectileRange; }
    public float GetProjectileDamage() { return projectileDamage; }
    public float GetProjectilePushback() { return projectilePushback; }
    public abstract void CreateProjectile();
    public abstract void WallHit();
    public abstract void EnemyHit();
}
