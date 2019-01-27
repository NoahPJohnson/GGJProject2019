using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileType7 : ProjectileInterface
{
    //Bounce Projectile 2
    public ProjectileType7()
    {
        this.projectileActive = true;
        this.projectileBounce = true;
        this.projectileSpeed = 30;
        this.projectileRange = 10;
        this.projectileDamage = 40;
        this.projectilePushback = 1000;
        this.projectileBounces = 9;
    }

    public override void CreateProjectile()
    {
        projectileBounces = 7;
        projectileActive = true;

    }

    public override void WallHit()
    {
        //Debug.Log("Wall Hit bounce");
        projectileBounces -= 1;
        //projectileSpeed += 5;
        if (projectileBounces <= 0)
        {
            //Debug.Log("Destroy bounce");
            projectileActive = false;
        }

    }

    public override void EnemyHit()
    {

    }
}
