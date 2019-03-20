using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveEToolBehaviour : ToolBehaviour
{
    public Color attractBeamColor;
    public Color repelBeamColor;
    
    [SerializeField]
    GameObject effectorBeam;

    float beamStrength;
    SpriteRenderer beamSpriteRenderer;
    AreaEffector2D areaEffector;

    void Awake()
    {
        areaEffector = effectorBeam.GetComponent<AreaEffector2D>();
        beamSpriteRenderer = effectorBeam.GetComponent<SpriteRenderer>();

        beamStrength = areaEffector.forceMagnitude;
        effectorBeam.SetActive(false);
    }

    public override void OnPrimaryBehaviour()
    {
        effectorBeam.SetActive(true);
        areaEffector.forceMagnitude = beamStrength;
        beamSpriteRenderer.color = attractBeamColor;
    }

    public override void OnSecondaryBehaviour()
    {
        effectorBeam.SetActive(true);
        areaEffector.forceMagnitude = -beamStrength;
        beamSpriteRenderer.color = repelBeamColor;
    }

    public override void OnPrimaryReleaseBehaviour()
    {
        effectorBeam.SetActive(false);
    }

    public override void OnSecondaryReleaseBehaviour()
    {
        effectorBeam.SetActive(false);
    }
}
