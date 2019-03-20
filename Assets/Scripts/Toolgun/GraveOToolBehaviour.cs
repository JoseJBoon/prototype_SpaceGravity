using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveOToolBehaviour : ToolBehaviour
{
    public float launchForce = 750;

    [SerializeField]
    GravityOrbBehaviour projectile;

    GravityOrbBehaviour currentProjectile;

    public override void OnPrimaryBehaviour()
    {
        if(!StopCurrentProjectile())
            CreateOrb();
    }

    public override void OnSecondaryBehaviour()
    {
        if(!StopCurrentProjectile())
        {
            CreateOrb();
            currentProjectile.ReverseForceMagnitude();
        }   
    }

    bool StopCurrentProjectile()
    {
        if(currentProjectile && !currentProjectile.IsFrozen)
        {
            currentProjectile.FreezeOrb();
            return true;
        }

        return false;
    }

    void CreateOrb()
    {
        if(currentProjectile)
            currentProjectile.DestroyOrb();

        currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        currentProjectile.LaunchOrb(transform.right * launchForce);
    }

    // No OnReleaseBehaviour
    public override void OnPrimaryReleaseBehaviour() { }
    public override void OnSecondaryReleaseBehaviour() { }

}