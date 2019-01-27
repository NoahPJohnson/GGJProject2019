using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileType0 : ProjectileInterface
{
    public ProjectileType0()
    {
        this.projectileActive = true;
        this.projectileSpeed = 20;
        this.projectileRange = 3;
        this.projectileDamage = 40;
        this.projectilePushback = 1500;
    }

    public override void CreateProjectile()
    {
        projectileActive = true;
    }

    public override void WallHit()
    {
        projectileActive = false;
    }

    public override void EnemyHit()
    {

    }
}
