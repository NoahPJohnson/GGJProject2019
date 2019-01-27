using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileType4 : ProjectileInterface
{
    //Laser Projectile (Normal 3)
    public ProjectileType4()
    {
        this.projectileActive = true;
        this.projectileStationary = true;
        this.projectileSpeed = 0;
        this.projectileRange = 3;
        this.projectileDamage = 40;
        this.projectilePushback = 500;
    }

    public override void CreateProjectile()
    {
        projectileActive = true;
    }

    public override void WallHit()
    {
        
    }

    public override void EnemyHit()
    {

    }
}
