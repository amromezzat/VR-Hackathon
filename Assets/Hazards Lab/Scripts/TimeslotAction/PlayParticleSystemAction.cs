using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Play Particle System Action")]
public class PlayParticleSystemAction : TimeslotAction
{
    ParticleSystem particleSystem;
    public override void Initialize(GameObject gameObject)
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    public override void TakeAction(float time)
    {
        particleSystem.Play(true);
    }
}
