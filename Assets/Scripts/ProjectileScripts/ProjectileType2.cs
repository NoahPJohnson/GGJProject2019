using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileType2 : ProjectileInterface
{
    public ProjectileType2()
    {
        this.projectileActive = true;
        this.projectileBounce = true;
        this.projectileSpeed = 25;
        this.projectileRange = 5;
        this.projectileDamage = 40;
        this.projectilePushback = 1000;
        this.projectileBounces = 4;
    }

    public override void CreateProjectile()
    {
        projectileBounces = 4;
        projectileActive = true;
        
    }

    public override void WallHit()
    {
        //Debug.Log("Wall Hit bounce");
        projectileBounces -= 1;
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
