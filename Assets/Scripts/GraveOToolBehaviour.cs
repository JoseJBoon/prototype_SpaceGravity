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
        CreateOrb();
    }

    public override void OnSecondaryBehaviour()
    {
        CreateOrb();
        currentProjectile.ReverseForceMagnitude();
    }

    void CreateOrb()
    {
        if(currentProjectile)
            currentProjectile.DestroyOrb();

        // TODO: Make weapon rotate
        currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        currentProjectile.LaunchOrb(transform.right * launchForce);
    }

    // No OnReleaseBehaviour
    public override void OnPrimaryReleaseBehaviour() { }
    public override void OnSecondaryReleaseBehaviour() { }

}