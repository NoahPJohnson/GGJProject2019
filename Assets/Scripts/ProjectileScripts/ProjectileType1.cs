using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileType1 : ProjectileInterface
{
    public ProjectileType1()
    {
        this.projectileActive = true;
        this.projectileSpeed = 25;
        this.projectileRange = 3;
        this.projectileDamage = 40;
        this.projectilePushback = 2000;
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
