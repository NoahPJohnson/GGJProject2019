using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileType5 : ProjectileInterface
{
    //SPLIT projectile
    public ProjectileType5()
    {
        this.projectileActive = true;
        this.projectileBounce = true;
        this.projectileSplit = true;
        this.projectileSpeed = 25;
        this.projectileRange = 8;
        this.projectileDamage = 40;
        this.projectilePushback = 1000;
        this.projectileBounces = 8;
    }

    public override void CreateProjectile()
    {
        projectileBounces = 8;
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
        else
        {
            //GameObject.Instantiate()
        }

    }

    public override void EnemyHit()
    {

    }
}
