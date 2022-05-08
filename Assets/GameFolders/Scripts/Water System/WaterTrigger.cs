using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    ParticleSystem particleSystem;

    List<ParticleSystem.Particle> particleList = new List<ParticleSystem.Particle>();

    //WaterShape waterShape;


    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        //waterShape = objects.Instance.middleGlass.GetComponent<WaterShape>();
    }

    private void OnParticleTrigger()
    {
        var numEnter = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particleList);

        for (var i = 0; i < numEnter; i++)
        {
            //Debug.Log("particleTrigger");

            ParticleSystem.Particle p = particleList[i];

            //Debug.Log(p.size);

            WaterManager.instance.middleGlass.GetComponent<WaterShape>().SetBlendValue(p.size * 5);
        }

        //   ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }

}